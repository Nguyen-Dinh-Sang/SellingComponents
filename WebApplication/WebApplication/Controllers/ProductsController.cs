using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SellingComponentsDBContext context;
        private SellingComponentsDBContext contextWrite;
        public static String  IdUser = "";
        public static String FullName = "";
        public ProductsController()
        {
            context = new SellingComponentsDBContext();
            contextWrite = new SellingComponentsDBContext();
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var sellingComponentsDBContext = context.Products.Include(p => p.IdClassifyNavigation);
            var menu = context.Classifies.ToList();
            foreach(var item in menu)
            {
                Console.WriteLine(item.Id);
            }    
            ViewBag.classify = menu;
            return View(await sellingComponentsDBContext.ToListAsync());
        }
        [HttpGet]
        public IActionResult Index(int Id,String searchString, int PageNumber = 1)
        {
            ViewBag.FullName = FullName;
            ViewBag.IdUser = IdUser;
            if(FullName == "")
            {
                return View();
            }
            IEnumerable<Product> listProDucts;
            IEnumerable<Combo> listCombo;
            var sellingComponentsDBContext = context.Products.Include(p => p.IdClassifyNavigation);
            var combo = context.Combos;
            var catalog = context.Catalogs;
            var cart = context.Carts.Where(t=>t.IdUser == int.Parse(IdUser));
            ViewBag.cart = cart.Count()!=0?cart.Count():0;
            Console.WriteLine("id là " + Id);
            ViewBag.PageNumber = PageNumber;
            ViewBag.TotalPages = Math.Ceiling(sellingComponentsDBContext.Count() / 6.0);
            ViewBag.Id = Id;
            
                if(!String.IsNullOrEmpty(searchString))
                {
                    listProDucts = sellingComponentsDBContext.Where(t=>t.ProductName.Contains(searchString));
                    listCombo = combo.Where(t => t.ComboName.Contains(searchString));
                    ViewBag.TotalPages = Math.Ceiling(listProDucts.Count() / 6.0);
                    ViewBag.searchString = searchString;
                }
                else
                {
                    listProDucts = sellingComponentsDBContext;
                    listCombo = combo;
                }
               
            var menu = context.Classifies.ToList();
            foreach (var item in menu)
            {
                Console.WriteLine(item.Id);
            }
            ViewBag.classify = menu;
            if(listCombo != null)
            {
                ViewBag.combo = listCombo.Skip((PageNumber - 1) * 6).Take(6).ToList();
            }
            else
            {
                ViewBag.combo = null;
            }

            ViewBag.catalog_menu = catalog;
            return View(listProDucts.Skip((PageNumber - 1) * 6).Take(6).ToList());
        }
        public IActionResult SanPham( int Id , int PageNumber = 1)
        {
            ViewBag.FullName = FullName;
            ViewBag.IdUser = IdUser;
            if (FullName == "")
            {
                return View();
            }
            IEnumerable<Product> listProDucts;
            var sellingComponentsDBContext = context.Products.Include(p => p.IdClassifyNavigation);
            var catalog = context.Catalogs;
            ViewBag.PageNumber = PageNumber;
            ViewBag.Id = Id;
            
            var menu = context.Classifies.ToList();
            var cart = context.Carts.Where(t => t.IdUser == int.Parse(IdUser));
            ViewBag.cart = cart.Count() != 0 ? cart.Count() : 0; 
            ViewBag.classify = menu;
            ViewBag.catalog_menu = catalog;
            listProDucts = sellingComponentsDBContext.Where(i => i.IdClassify == Id);
                ViewBag.TotalPages = Math.Ceiling(listProDucts.Count() / 6.0);
            return View(listProDucts.Skip((PageNumber - 1) * 6).Take(6).ToList());
            
            }
        public IActionResult Combo(int Id, int PageNumber = 1)
        {
            ViewBag.FullName = FullName;
            ViewBag.IdUser = IdUser;
            if (FullName == "")
            {
                return View();
            }
            IEnumerable<Combo> listCombo;
            var sellingComponentsDBContext = context.Products.Include(p => p.IdClassifyNavigation);
            var catalog = context.Catalogs;
            var combo = context.Combos.Include(c => c.IdCatalogNavigation);
            ViewBag.PageNumber = PageNumber;
            ViewBag.Id = Id;
            
            var menu = context.Classifies.ToList();
            var cart = context.Carts.Where(t => t.IdUser == int.Parse(IdUser));
            ViewBag.cart = cart.Count() != 0 ? cart.Count() : 0; 
            ViewBag.classify = menu;
            ViewBag.catalog_menu = catalog;
            listCombo = combo.Where(i => i.IdCatalog == Id);
            ViewBag.TotalPages = Math.Ceiling(listCombo.Count() / 6.0);
            return View(listCombo.Skip((PageNumber - 1) * 6).Take(6).ToList());
        }
        public IActionResult ChiTietSanPham(int Id)
        {
            ViewBag.FullName = FullName;
            ViewBag.IdUser = IdUser;
            if (FullName == "")
            {
                return View();
            }
            var proDuct = context.Products.Include(t => t.IdClassifyNavigation).Where(w => w.Id == Id);
            var catalog = context.Catalogs;
            var menu = context.Classifies.ToList();
            var cart = context.Carts.Where(t => t.IdUser == int.Parse(IdUser));
            ViewBag.cart = cart.Count() != 0 ? cart.Count() : 0;
            ViewBag.classify = menu;
            ViewBag.catalog_menu = catalog;
            
            return View(proDuct.ToList());
        }
        public IActionResult ChiTietCombo(int Id)
        {
            ViewBag.FullName = FullName;
            ViewBag.IdUser = IdUser;
            if (FullName == "")
            {
                return View();
            }
            var combo = context.ComboDetails.Include(t => t.IdComboNavigation).Include(cp => cp.IdProductNavigation).Where(w => w.IdComboNavigation.Id == Id);
            var catalog = context.Catalogs;
            var menu = context.Classifies.ToList();
            var cart = context.Carts.Where(t => t.IdUser == int.Parse(IdUser));
            ViewBag.cart = cart.Count() != 0 ? cart.Count() : 0;
            ViewBag.classify = menu;
            ViewBag.catalog_menu = catalog;

            return View(combo.ToList());
        }
        public IActionResult Giohang()
        {
            ViewBag.FullName = FullName;
            ViewBag.IdUser = IdUser;
            if (FullName == "")
            {
                return View();
            }
            var carts = context.Carts.Include(t => t.IdComboNavigation).Include(t => t.IdProductNavigation).Where(t => t.IdUser == int.Parse(IdUser));
            var catalog = context.Catalogs;
            var menu = context.Classifies.ToList();
           
            ViewBag.cart = carts.Count() != 0 ? carts.Count() : 0;
            ViewBag.classify = menu;
            ViewBag.catalog_menu = catalog;
           
            Decimal tongtien = 0;
            foreach( var item in carts)
            {
                if(item.IdCombo == null)
                {
                    tongtien += item.Amount * Convert.ToDecimal(item.IdProductNavigation.Price);
                }
                else
                {
                    tongtien += item.Amount * Convert.ToDecimal(item.IdComboNavigation.Price);
                }
               
            }
            ViewBag.giohang_tongtien = tongtien;
            return View(carts.ToList());
        }
        [HttpGet]
        public IActionResult SanPham_GioHang(int id, int iduser)
        {
            
            Console.WriteLine("id là" + id + "iduser là " + iduser);
            //var productInCart = context.Carts.Where(t => t.IdProduct == id);
            var queryProductInCart = (from c in context.Carts
                                      where c.IdProduct == id && c.IdUser == iduser
                                      select c);
            Cart cart = queryProductInCart.Count() != 0 ? queryProductInCart.First() : null;
            Cart carts = new Cart();
            if (cart != null)
            {
                var ud = context.Carts.Find(cart.Id);
                ud.IdUser = cart.IdUser;
                ud.IdCombo = cart.IdCombo;
                ud.IdProduct = cart.IdProduct;
                ud.Amount = 1 + int.Parse(cart.Amount + "");
                context.SaveChanges();
            }
            else
            {

                carts.IdUser = iduser;
                carts.IdProduct = id;
                carts.Amount = 1;
                context.Carts.Add(carts);
                context.SaveChanges();
            }    

         


            return new JsonResult("Thêm thành công.");

        }
        public IActionResult Delete_Cart(int id)
        {
            var cart = context.Carts.Find(id);
            context.Carts.Remove(cart);
            context.SaveChanges();
            return new JsonResult("Xóa thành công.");
        }
        public IActionResult Combo_GioHang(int id, int iduser)
        {
            var queryProductInCart = (from c in context.Carts
                                      where c.IdCombo == id && c.IdUser == iduser
                                      select c);
            Cart cart = queryProductInCart.Count() != 0 ? queryProductInCart.First() : null;
            Cart carts = new Cart();
            if (cart != null)
            {
                var ud = context.Carts.Find(cart.Id);
                ud.IdUser = cart.IdUser;
                ud.IdCombo = cart.IdCombo;
                ud.IdProduct = cart.IdProduct;
                ud.Amount = 1 + int.Parse(cart.Amount + "");
                context.SaveChanges();
            }
            else
            {

                carts.IdUser = iduser;
                carts.IdCombo = id;
                carts.Amount = 1;
                context.Carts.Add(carts);
                context.SaveChanges();
            }
            return new JsonResult("Thêm thành công.");

        }
        public IActionResult Update_Soluong(int id, int soluong)
        {
            var ud = context.Carts.Find(id);
            ud.Amount = soluong;
            context.SaveChanges();
            return new JsonResult("ok");
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products
                .Include(p => p.IdClassifyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        public IActionResult Login()
        {
            return View();        }
        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["IdClassify"] = new SelectList(context.Classifies, "Id", "ClassifyDetail");
            return View();
        }
        [HttpGet]
        public IActionResult DatHang(int IdUser,Decimal TotalCost , String DeliveryAddress , DateTime DeliveryDate)
        {
           
            Order order = new Order();
            order.IdUser = IdUser;
            order.TotalCost = TotalCost;
            order.DeliveryAddress = DeliveryAddress;
            order.DeliveryDate =  DeliveryDate;
            context.Add(order);
             context.SaveChanges();
            var carts = context.Carts.Include(t => t.IdComboNavigation).Include(t => t.IdProductNavigation).Where(t => t.IdUser == IdUser);
            Console.WriteLine(order.Id);

            foreach (var item in carts)
            {
                if(item.IdCombo == null)
                {
                    OrdersDetail ordersDetail = new OrdersDetail()
                    {
                        IdOrders = order.Id
                ,
                        IdCombo = item.IdCombo,
                        IdProduct = item.IdProduct,
                        Amount = item.Amount,
                        Price = item.IdProductNavigation.Price
                    };
                    var ud = context.Products.Find(ordersDetail.IdProduct);
                    ud.Amount = ud.Amount - ordersDetail.Amount;
                    contextWrite.Add(ordersDetail);
                    contextWrite.SaveChanges();
                    contextWrite.Update(ud);
                    contextWrite.SaveChanges();
                    contextWrite.Remove(item);
                    contextWrite.SaveChanges();
                }
                else
                {
                    OrdersDetail ordersDetail = new OrdersDetail()
                    {
                        IdOrders = order.Id
               ,
                        IdCombo = item.IdCombo,
                        IdProduct = item.IdProduct,
                        Amount = item.Amount,
                        Price = item.IdComboNavigation.Price
                    };
                    
                   
                    contextWrite.Add(ordersDetail);
                    contextWrite.SaveChanges();
                    contextWrite.Remove(item);
                    contextWrite.SaveChanges();
                }
                
            }
            return new JsonResult("Đặt hàng thành công");
        }
        public IActionResult Banhang_Login(String UserName , String Password)
        {
            var user = context.UserInformations.Where(t => t.UserName.Contains(UserName)).Where(t => t.Password.Contains(Password));
           
            
            if (user.Count() !=0)
            {
                UserInformation userInformation = user.First();
                
                HttpContext.Session.SetString("FullName", userInformation.FullName);
                HttpContext.Session.SetString("IdUser", userInformation.Id+"");
                FullName = userInformation.FullName;
                IdUser = userInformation.Id+"";
                return new JsonResult("1");

            }
            else
            {
                return new JsonResult("0");
            }
            
        }
        public IActionResult Banhang_sigup(String UserName, String Password , String FullName)
        {
            var user = context.UserInformations.Where(t=>t.UserName.Contains(UserName));
            if(user.Count() !=0)
            {
                return new JsonResult("0");
            }
            else
            {
                UserInformation userInformation = new UserInformation() {UserName=UserName,Password=Password,FullName=FullName,PhoneNumber="0983034305",Address="tranthanh@gmail.com",IdRole=1 };
                contextWrite.Add(userInformation);
                contextWrite.SaveChanges();
                return new JsonResult("1");
            }
        }
        public IActionResult Banhang_Logout(String ok)
        {
            FullName = "";
            IdUser = "";
            return new JsonResult("ok");
        }
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Amount,Price,Detail,IdClassify,DateCreated")] Product product)
        {
            if (ModelState.IsValid)
            {
                context.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClassify"] = new SelectList(context.Classifies, "Id", "ClassifyDetail", product.IdClassify);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["IdClassify"] = new SelectList(context.Classifies, "Id", "ClassifyDetail", product.IdClassify);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Amount,Price,Detail,IdClassify,DateCreated")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(product);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClassify"] = new SelectList(context.Classifies, "Id", "ClassifyDetail", product.IdClassify);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products
                .Include(p => p.IdClassifyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await context.Products.FindAsync(id);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return context.Products.Any(e => e.Id == id);
        }
    }
}
