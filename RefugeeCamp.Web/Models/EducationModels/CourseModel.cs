﻿using RefugeeCamp.Domaine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RefugeeCamp.Web.Models.EducationModels
{
    public class CourseModel : Course
    {
        public IEnumerable<SelectListItem> MLevel { get; set; }
    }
}