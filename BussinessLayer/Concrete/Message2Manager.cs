﻿ using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public void AddT(Message2 t)
        {
            _message2Dal.Insert(t);
        }

        public void DeleteT(Message2 t)
        {
            _message2Dal.Delete(t);
        }

        public List<Message2> GetSendboxListByWriter(int id)
        {
            return _message2Dal.GetSendBoxWithMessageByWriter(id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _message2Dal.GetInBoxWithMessageByWriter(id);
        }

        public List<Message2> GetList()
        {
            return _message2Dal.GetListAll();
        }

        public Message2 TGetById(int id)
        {
            return _message2Dal.GetById(id);
        }

        public void UpdateT(Message2 t)
        {
            _message2Dal.Update(t);
        }
    }
}
