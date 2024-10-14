using backendPizzaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("products")] // Mapeia a tabela "products"
public class ProductModel
{
    [Key]
    public int Id { get; set; } // Usando int como tipo de chave primária

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
    public double Price { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int Amount { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int? CategoryId { get; set; } 

    public CategoryModel? Category { get; set; }


    public ICollection<OrderItemsModel>? Items { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now; 

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now; 
}
