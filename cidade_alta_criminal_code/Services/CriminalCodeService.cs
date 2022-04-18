using AutoMapper;
using cidade_alta_criminal_code.Data;
using cidade_alta_criminal_code.Data.Dtos.CriminalCodeDto;
using cidade_alta_criminal_code.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace cidade_alta_criminal_code.Services

{
    public class CriminalCodeService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        // private UserManager<IdentityUser<int>> _userManager;
        private UserManager<ApplicationUser> _userManager;

        // public CriminalCodeService(ApplicationDbContext context, IMapper mapper, UserManager<IdentityUser<int>> userManager)
        public CriminalCodeService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CreateCriminalCode(CreateCriminalCodeDto criminalCodeDto, string userId)
        {
            criminalCodeDto.CreateUserId = userId;
            criminalCodeDto.UpdateUserId = userId;
            criminalCodeDto.CreatedDate = DateTime.Now;
            criminalCodeDto.UpdatedDate = DateTime.Now;
            
            CriminalCode criminalCode = _mapper.Map<CriminalCode>(criminalCodeDto);
            _context.CriminalCodes.Add(criminalCode);
            int isCreated = _context.SaveChanges();

            if (isCreated == 1) return Result.Ok();
            return Result.Fail("Falha ao cadastrar o usuário");

        }

        public Result UpdateCriminalCode(int id, UpdateCriminalCodeDto criminalCodeDto, string userId)
        {
            CriminalCode criminalCode = _context.CriminalCodes.FirstOrDefault(criminalCode => criminalCode.Id == id);

            criminalCodeDto.UpdatedDate = DateTime.Now;
       

            if (criminalCode == null)
            {
                return Result.Fail("Código Criminal não encontrado");
            }
            // _mapper.Map(criminalCodeDto, criminalCode);
            criminalCode.Name = criminalCodeDto.Name;
            criminalCode.Description = criminalCodeDto.Description;
            criminalCode.Penalty = criminalCodeDto.Penalty / 100;
            criminalCode.PrisionTime = criminalCodeDto.PrisionTime;
            criminalCode.StatusId = criminalCodeDto.StatusId;
            criminalCode.UpdateUserId = userId;
            _context.SaveChanges();
            return Result.Ok();
        }

        public List<ReadCriminalCodeDto> ListCriminalCodes(string ordered, string order)
        {
            List<CriminalCode> criminalCodes;

            string ordered_field = ordered ?? "Name";

            var orderBy = ToLambda<CriminalCode>(ordered_field);

            if (order == "asc")
            {
                criminalCodes = _context.CriminalCodes.Include(i => i.CreateUser).Include(j => j.UpdateUser).OrderBy(orderBy).ToList();
            }
            else if (order == "desc")
            {
                criminalCodes = _context.CriminalCodes.Include(i => i.CreateUser).Include(j => j.UpdateUser).OrderByDescending(orderBy).ToList();
            }
            else
            {
                criminalCodes = _context.CriminalCodes.Include(i => i.CreateUser).Include(j => j.UpdateUser).ToList();
            }

            if (criminalCodes != null)
            {
                List<ReadCriminalCodeDto> readDto = _mapper.Map<List<ReadCriminalCodeDto>>(criminalCodes);
                return readDto;
            }

            return null;
        }

        public ReadCriminalCodeDto Details(int id)
        {
            CriminalCode criminalCode = _context.CriminalCodes.Include(i => i.CreateUser).
                Include(j => j.UpdateUser).
                Include(s => s.Status).
                FirstOrDefault(criminalCode => criminalCode.Id == id);
            if (criminalCode != null)
            {
                ReadCriminalCodeDto criminalCodeDto = _mapper.Map<ReadCriminalCodeDto>(criminalCode);

                return criminalCodeDto;
            }

            return null;
        }

        public Result DeleteCriminalCode(int id)
        {
            CriminalCode criminalCode = _context.CriminalCodes.FirstOrDefault(criminalCode => criminalCode.Id == id);
            if(criminalCode == null)
            {
                return Result.Fail("Código Criminal não encontrado");
            }
            _context.Remove(criminalCode);
            _context.SaveChanges();
            return Result.Ok();
        }
        public static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }

    }
}
