using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Triz.BLL;
using Triz.Model;

namespace MvcApplication1.Controllers
{
    public class QuestionDescriptionsController : ApiController
    {
        // GET api/QuestionDescriptions/5
        public QuestionDescriptionInfo Get(string id)
        {
            return new QuestionDescriptionLogic().GetByProjectID(id);
        }

        // GET api/QuestionDescriptions
        public object Get([FromUri]string Note, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<QuestionDescriptionInfo> QuestionDescriptionInfoList = new QuestionDescriptionLogic().Query(Note, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = QuestionDescriptionInfoList
            };
        }

        // POST api/QuestionDescriptions
        public void Post([FromBody]QuestionDescriptionInfo QuestionDescriptionInfo)
        {
            new QuestionDescriptionLogic().SaveQuestionDescription(QuestionDescriptionInfo);
        }

        public void Put([FromBody]QuestionDescriptionInfo QuestionDescriptionInfo)
        {
            new QuestionDescriptionLogic().SaveQuestionDescription(QuestionDescriptionInfo);
        }

        // DELETE api/QuestionDescriptions/5
        public void Delete(int id)
        {
            new QuestionDescriptionLogic().DeleteQuestionDescription(id);
        }

        // DELETE api/QuestionDescriptions/5
        public void Delete(string ids)
        {
            new QuestionDescriptionLogic().DeleteQuestionDescription(ids);
        }

    }
}


