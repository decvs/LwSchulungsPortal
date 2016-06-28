﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ParticipantsRepository
    {
        private readonly TpContext _database;

        public ParticipantsRepository()
        {
            _database = new TpContext();
        }

        public IQueryable<Participant> Query => _database.Participants;

        public void Insert(Participant participant)
        {
            _database.Participants.Add(participant);
            _database.SaveChanges();
        }

        public Participant GetById(int id)
        {
            var participant = _database.Participants.Find(id);
            return participant;
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            _database.Participants.Remove(item);
            _database.SaveChanges();
        }

        public void Update(Participant model)
        {
            //if (_database.Entry(model).State == EntityState.Detached)
            //{
            //    _database.Participants.Attach(model);
            //    _database.Entry(model).State = EntityState.Modified;
            //}

            _database.Entry(model).State = EntityState.Modified;

            _database.SaveChanges();
        }
    }
}