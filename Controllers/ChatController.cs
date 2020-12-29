using CursoAngularNETCoreHdeleon.Models;
using CursoAngularNETCoreHdeleon.Models.Responses;
using CursoAngularNETCoreHdeleon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoAngularNETCoreHdeleon.Controllers {

    [Route("api/[controller]")]
    public class ChatController : Controller {

        private readonly MyDbContext context;

        public ChatController(MyDbContext context) {
            this.context = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<MessageViewModel> Message() {
            List<MessageViewModel> messages = (from m in context.Message
                                               orderby m.ID descending
                                               select new MessageViewModel {
                                                   ID = m.ID,
                                                   Name = m.Name,
                                                   Text = m.Text
                                               }).ToList();

            return messages;
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody] MessageViewModel model) {
            MyResponse response = new MyResponse();

            try {
                Message message = new Message() { Name = model.Name, Text = model.Text };
                context.Message.Add(message);
                context.SaveChanges();
                response.Success = 1;
                response.Data = message;

            } catch (Exception ex) {
                response.Success = 0;
                response.Message = ex.Message;
            }

            return response;
        }

    }

}