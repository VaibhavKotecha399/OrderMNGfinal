using AutoMapper;
using ORDMNG.DTO;
using ORDMNG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORDMNG.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UsersDTO, Users>().ReverseMap();
            CreateMap<ProductsDTO, Products>().ReverseMap();
            CreateMap<CartsDTO, Cart>().ReverseMap();
            CreateMap<CartItemsDTO, CartItems>().ReverseMap();
            CreateMap<PaymentDTO, Payment>().ReverseMap();
            CreateMap<OrdersDTO, Orders>().ReverseMap();
            CreateMap<OrderItemsDTO, OrderItems>().ReverseMap(); 
        }
    }
}
