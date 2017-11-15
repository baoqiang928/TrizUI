using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class QuestionAnalyseLogic
    {
        public void DeleteQuestionAnalyse(int id)
        {
            new QuestionAnalyseDAL().Delete(id);
        }

        public void DeleteQuestionAnalyse(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new QuestionAnalyseDAL().Delete(int.Parse(id));
            }
        }

        public void SaveQuestionAnalyse(QuestionAnalyseInfo QuestionAnalyseInfo)
        {
            new QuestionAnalyseDAL().Update(QuestionAnalyseInfo);
        }
        public QuestionAnalyseInfo GetByID(string ID)
        {
            return new QuestionAnalyseDAL().GetByID(int.Parse(ID));
        }

        public QuestionAnalyseInfo GetByProjectID(string ID)
        {
            return new QuestionAnalyseDAL().GetByProjectID(int.Parse(ID));
        }

        
        public List<QuestionAnalyseInfo> Query(string IdealResolution1, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new QuestionAnalyseDAL().Query(IdealResolution1, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


