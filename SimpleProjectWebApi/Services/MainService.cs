using SimpleProject.Data.Repositories;
using SimpleProject.Entities;
using SimpleProject.Interfaces;

namespace SimpleProjectWebApi.Services
{
    public class MainService : IMainService
    {
        private readonly IRepositoryBase<Product> productRepository;
        private readonly ILogger<MainService> logger;

        public MainService(IRepositoryBase<Product> productRepository, ILogger<MainService> logger)
        {
            this.productRepository = productRepository;
            this.logger = logger;
        }

        public Task<Product> Create(Product product)
        {
            try
            {
                if (product is not null)
                {
                    productRepository.Create(product);
                    productRepository.SaveChanges();
                    return Task.FromResult(product);
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
            return Task.FromResult(new Product());
        }

        public Task<Product> DeleteById(long Id)
        {
            try
            {
                var product = productRepository.FindByCondition(condition => condition.Id == Id).SingleOrDefault();
                if (product is not null)
                {
                    productRepository.Delete(product);
                    productRepository.SaveChanges();
                    return Task.FromResult(product!);
                }

            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
            return Task.FromResult(new Product());
        }

        public Task<List<Product>> GetAll()
        {
            try
            {
                var products = productRepository.FindByCondition(x => x.Id != 0).ToList();
                return Task.FromResult(products);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
            return Task.FromResult(new List<Product>());
        }

        public Task<Product> GetById(long Id)
        {
            try
            {
                var product = productRepository.FindByCondition(x => x.Id == Id).SingleOrDefault();
                if (product is not null) return Task.FromResult(product);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
            return Task.FromResult(new Product());
        }

        public Task<Product> Update(Product product)
        {
            try
            {
                if (product is not null)
                {
                    productRepository.Update(product);
                    productRepository.SaveChanges();
                    return Task.FromResult(product);
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
            return Task.FromResult(new Product());
        }
    }
}
