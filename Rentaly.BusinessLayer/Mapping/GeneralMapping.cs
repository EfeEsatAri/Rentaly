using AutoMapper;
using Rentaly.DtoLayer.BranchDtos;
using Rentaly.DtoLayer.BrandDtos;
using Rentaly.DtoLayer.CarDtos;
using Rentaly.DtoLayer.CarModelDtos;
using Rentaly.DtoLayer.CategoryDtos;
using Rentaly.DtoLayer.CommentDtos;
using Rentaly.DtoLayer.CustomerDtos;
using Rentaly.DtoLayer.FeaturesDtos;
using Rentaly.DtoLayer.FooterDtos;
using Rentaly.DtoLayer.QuestionsDtos;
using Rentaly.DtoLayer.RentalDtos;
using Rentaly.DtoLayer.ReservationDtos;
using Rentaly.DtoLayer.StepDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Branch, CreateBranchDto>().ReverseMap();
            CreateMap<Branch, ResultBranchDto>().ReverseMap();
            CreateMap<Branch, GetByIdBranchDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();

            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();

            CreateMap<Car, CreateCarDto>().ReverseMap();
            CreateMap<Car, ResultCarDto>().ReverseMap();
            CreateMap<Car, GetByIdCarDto>().ReverseMap();
            CreateMap<Car, UpdateCarDto>().ReverseMap();

            CreateMap<CarModel, CreateCarModelDto>().ReverseMap();
            CreateMap<CarModel, ResultCarModelDto>().ReverseMap();
            CreateMap<CarModel, GetByIdCarModelDto>().ReverseMap();
            CreateMap<CarModel, UpdateCarModelDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, ResultCommentDto>().ReverseMap();
            CreateMap<Comment, GetByIdCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();

            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, GetCustomerByIdDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();

            CreateMap<Features, CreateFeaturesDto>().ReverseMap();
            CreateMap<Features, ResultFeaturesDto>().ReverseMap();
            CreateMap<Features, GetByIdFeaturesDto>().ReverseMap();
            CreateMap<Features, UpdateFeaturesDto>().ReverseMap();

            CreateMap<Footer, CreateFooterDto>().ReverseMap();
            CreateMap<Footer, ResultFooterDto>().ReverseMap();
            CreateMap<Footer, GetByIdFooterDto>().ReverseMap();
            CreateMap<Footer, UpdateFooterDto>().ReverseMap();

            CreateMap<Questions, CreateQuestionsDto>().ReverseMap();
            CreateMap<Questions, ResultQuestionsDto>().ReverseMap();
            CreateMap<Questions, GetByIdQuestionsDto>().ReverseMap();
            CreateMap<Questions, UpdateQuestionsDto>().ReverseMap();

            CreateMap<Rental, CreateRentalDto>().ReverseMap();
            CreateMap<Rental, ResultRentalDto>().ReverseMap();
            CreateMap<Rental, GetByIdRentalDto>().ReverseMap();
            CreateMap<Rental, UpdateRentalDto>().ReverseMap();

            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, ResultReservationDto>().ReverseMap();
            CreateMap<Reservation, GetByIdReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();

            CreateMap<Step, CreateStepDto>().ReverseMap();
            CreateMap<Step, ResultStepDto>().ReverseMap();
            CreateMap<Step, GetByIdStepDto>().ReverseMap();
            CreateMap<Step, UpdateStepDto>().ReverseMap();

            CreateMap<GetByIdBrandDto, UpdateBrandDto>().ReverseMap();
            CreateMap<GetByIdCarModelDto, UpdateCarModelDto>().ReverseMap();
            CreateMap<GetByIdCommentDto, UpdateCommentDto>().ReverseMap();
            CreateMap<GetByIdFeaturesDto, UpdateFeaturesDto>().ReverseMap();
            CreateMap<GetByIdFooterDto, UpdateFooterDto>().ReverseMap();
            CreateMap<GetByIdQuestionsDto, UpdateQuestionsDto>().ReverseMap();
            CreateMap<GetByIdReservationDto, UpdateReservationDto>().ReverseMap();
            CreateMap<GetByIdStepDto, UpdateStepDto>().ReverseMap();

        }
    }
}
