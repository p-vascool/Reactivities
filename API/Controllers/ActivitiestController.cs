﻿using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiestController : BaseApiController
    {
        private readonly DataContext _dataContext;
        public ActivitiestController(DataContext data)
        {
            this._dataContext = data;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivitiest()
        {
            return await _dataContext.Activities.ToListAsync();
        }

        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _dataContext.Activities.FindAsync(id);
        }
    }
}
