using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class QuestionDescriptionLogic
    {
        public void DeleteQuestionDescription(int id)
        {
            new QuestionDescriptionDAL().Delete(id);
        }

        public void DeleteQuestionDescription(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new QuestionDescriptionDAL().Delete(int.Parse(id));
            }
        }

        public void SaveQuestionDescription(QuestionDescriptionInfo QuestionDescriptionInfo)
        {
            //if (QuestionDescriptionInfo.ID == null)
            //{
            //    new QuestionDescriptionDAL().Add(QuestionDescriptionInfo);
            //    return;
            //}
            new QuestionDescriptionDAL().Update(QuestionDescriptionInfo);

        }

        public QuestionDescriptionInfo GetByID(string ID)
        {
           return new QuestionDescriptionDAL().GetByID(int.Parse(ID));
        }
        public QuestionDescriptionInfo GetByProjectID(string ID)
        {
            return new QuestionDescriptionDAL().GetByProjectID(int.Parse(ID));
        }
        
        public List<QuestionDescriptionInfo> Query(string Note, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new QuestionDescriptionDAL().Query(Note, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


