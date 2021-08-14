using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
  public  class ManagerMng:IManagerService


  {
      private IManagerDal _managerDal;
      private IUserService _userService;

      public ManagerMng(IManagerDal managerDal, IUserService userService)
      {
          _managerDal = managerDal;
          _userService = userService;
      }
      [CacheAspect]
        public IDataResult<List<Manager>> GetAll()
        {
            return new SuccessDataResult<List<Manager>>(this._managerDal.GetAll(), Messages.ManagerListed);
        }
        [CacheRemoveAspect("IManagerService.Get")]
        public IResult Add(Manager manager)
        {
            _managerDal.Add(manager);
            return new SuccessResult(Messages.ManagerAdded);
        }
        [CacheAspect]
        public IDataResult<Manager> GetById(int managerId)
        {
            return new SuccessDataResult<Manager>(_managerDal.Get(m => m.ManagerId == managerId), Messages.ManagerFound);

        }

        public IDataResult<Manager> GetByUserId(int userId)
        {

            return new SuccessDataResult<Manager>(_managerDal.Get(m => m.UserId == userId), Messages.ManagerFound);
        }

        public IDataResult<Manager> GetByMail(string mail)
        {
          var user =  this._userService.GetByMail(mail).Data;
         return new SuccessDataResult<Manager>( this.GetByUserId(user.Id).Data,Messages.ManagerFound);
        }


        [CacheAspect]
        public IDataResult<List<ManagerDto>> GetAllManagerDetails()
        {
            return new SuccessDataResult<List<ManagerDto>>(_managerDal.GetAllManagerDetails(), Messages.ManagerListed);
        }


        private IResult UserExists(string mail)
        {
            if (_userService.GetByMail(mail).Data == null)
            {
                return new ErrorResult("Kullanıcı bulunamadı");
            }

            return new SuccessResult();
        }
  }
}
