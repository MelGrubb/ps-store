using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Common.Contracts;
using Store.Domain.Repositories;
using Store.Services.Contracts.Order;
using Store.Services.Framework;
using Store.Services.Mapping;

namespace Store.Services
{
    public interface IOrderService : IService
    {
        Task<OrderDto> AddAsync(int userId, OrderDto dto);
        Task<OrderDto> DeleteAsync(int userId, int id);
        Task<OrderDto> GetAsync(int userId, int id);
        Task<IList<OrderDto>> GetAsync(int userId, PagingOptions pagingOptions);
        Task<OrderDto> UpdateAsync(int userId, OrderDto dto);
    }

    public class OrderService : Service, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> AddAsync(int userId, OrderDto dto)
        {
            var model = OrderMapper.Map(dto);
            var newModel = await _orderRepository.AddAsync(userId, model);
            var result = OrderDtoMapper.Map(newModel);

            return result;
        }

        public async Task<OrderDto> DeleteAsync(int userId, int id)
        {
            var model = await _orderRepository.DeleteAsync(userId, id);
            var result = OrderDtoMapper.Map(model);

            return result;
        }

        public async Task<OrderDto> GetAsync(int userId, int id)
        {
            var model = await _orderRepository.GetAsync(userId, id);
            var result = OrderDtoMapper.Map(model);

            return result;
        }

        public async Task<IList<OrderDto>> GetAsync(int userId, PagingOptions pagingOptions)
        {
            var models = await _orderRepository.GetAsync(userId, null, pagingOptions);
            var results = OrderDtoMapper.Map(models);

            return results;
        }

        public async Task<OrderDto> UpdateAsync(int userId, OrderDto dto)
        {
            var model = await _orderRepository.GetAsync(userId, dto.Id);
            if (model == null)
            {
                return null;
            }

            OrderMapper.Map(dto, model);
            await _orderRepository.SaveChangesAsync(userId);

            // Return a fresh copy of the saved object.
            return await GetAsync(userId, model.Id);
        }
    }
}
