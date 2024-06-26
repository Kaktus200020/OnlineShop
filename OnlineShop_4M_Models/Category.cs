﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop_4M_Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

        [Required]
		[DisplayName("Номер отображения")]
		[Range(1, int.MaxValue, ErrorMessage = "Номер отображения должен быть больше 0")]
        public int DisplayOrder { get; set; }
	}
}

