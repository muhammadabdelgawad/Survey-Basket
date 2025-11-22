using AutoMapper;
using SurveyBasket.Application.Abstractions.DTOs.Answers;
using SurveyBasket.Application.Abstractions.DTOs.Questions.Requests;
using SurveyBasket.Application.Abstractions.DTOs.Questions.Responses;
using SurveyBasket.Domain.Entities;

namespace SurveyBasket.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map QuestionRequest to Question with custom Answers mapping
            CreateMap<QuestionRequest, Question>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => 
                    src.QuestionAnswers.Select(answer => new Answer 
                    { 
                        Content = answer,
                        IsActive = true 
                    })))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.poll, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedById, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            // Map Question to QuestionResponse
            CreateMap<Question, QuestionResponse>()
                .ForMember(dest => dest.QuestionAnswers, opt => opt.MapFrom(src => src.Answers));

            // Map Answer to AnswerResponse
            CreateMap<Answer, AnswerResponse>();
        }
    }
}
