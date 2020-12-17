using AutoMapper;
using Business.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.Business.DTO;
using WindowsForms.DataAccess.Entity;
using WindowsForms.DataAccess.Repository;

namespace WindowsForms.Business.Service
{
    public class ClassifyService
    {
        private ClassifyRepository classifyRepository = ClassifyRepository.getInstance();

        private static ClassifyService instance;

        private IMapper mapper = new MappingConfig().config();

        private ClassifyService()
        {

        }

        public static ClassifyService getInstance()
        {
            if (instance == null)
            {
                instance = new ClassifyService();
            }

            return instance;
        }

        public List<ClassifyDTO> getClassifies()
        {
            return new List<ClassifyDTO>(mapper.Map<IEnumerable<Classify>, IEnumerable<ClassifyDTO>>(classifyRepository.getClassifies()));
        }

        public ClassifyDTO getClassifyByIdProduct(int id)
        {
            return mapper.Map<Classify, ClassifyDTO>(classifyRepository.getClassifyByIdProduct(id));
        }

        public List<ClassifyDTO> getClassifyBySearchString(string searchValue)
        {
            return new List<ClassifyDTO>(mapper.Map<IEnumerable<Classify>, IEnumerable<ClassifyDTO>>(classifyRepository.getClassifyBySearchString(searchValue)));
        }

        public void create(ClassifyDTO classify)
        {
            classifyRepository.create(mapper.Map<ClassifyDTO, Classify>(classify));
        }

        public void edit(ClassifyDTO classify)
        {
            classifyRepository.edit(mapper.Map<ClassifyDTO, Classify>(classify));
        }

        public void delete(int id)
        {
            classifyRepository.delete(id);
        }
    }
}
