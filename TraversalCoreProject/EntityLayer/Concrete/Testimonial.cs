﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Testimonial
	{
        [Key]
        public int TestimonialID { get; set; }
		public string Client { get; set; }
		public string Comment { get; set; }
		public string ClientImage { get; set; }
		public bool Status { get; set; }
	}
}

