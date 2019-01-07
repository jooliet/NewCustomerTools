﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoSwitch.CustomerTools.DB;
using static GoSwitch.CustomerTools.Models.NewCallCenters.ParamModels;

namespace GoSwitch.CustomerTools.DAL
{
    public class NewCallCenters
    {
        public static bool InsertNewCallCenter(ParamInsertCallCenter param)
        {
            try
            {
                DB.NewCallCenter newCallCenter = GetCallCenterByCode(param.CallCenterCode);
                if (newCallCenter!=null)
                {
                    return false;
                }
                else
                {
                    newCallCenter = new NewCallCenter();
                    newCallCenter.CallCenterCode = param.CallCenterCode;
                    newCallCenter.CallCenterName = param.CallCenterName;
                    newCallCenter.IsActive = param.IsActive;
                    newCallCenter.CreatedDateTime = DateTime.Now;
                    DataRepositoryFactory.CurrentRepository.Create<DB.NewCallCenter>(newCallCenter);
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static NewCallCenter GetCallCenterByCode(string ccCode)
        {
            var result = DataRepositoryFactory.CurrentRepository.GetAll<DB.NewCallCenter>().Where(x => x.IsActive && x.CallCenterCode == ccCode);
            return result.FirstOrDefault();
        }

        public static List<DB.NewCallCenter> GetAllCallCenters()
        {
            List<DB.NewCallCenter> result = DataRepositoryFactory.CurrentRepository.GetAll<DB.NewCallCenter>().ToList();
            return result;
        }
    }
}