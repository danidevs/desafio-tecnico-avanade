using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicoDeEstoque.Data;
using ServicoDeEstoque.Modelos;

namespace ServicoDeEstoque.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorDeProduto : ControllerBase
    {
        private readonly StockDbContext _context;
        public ControladorDeProduto(StockDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produto = await _context.Produtos.ToListAsync();
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        private object Get()
        {
            throw new NotImplementedException();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, Produto produto)
        {
            var existing = await _context.Produtos.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Nome = produto.Nome;
            existing.Descricao = produto.Descricao;
            existing.Preco = produto.Preco;
            existing.Quantidade = produto.Quantidade;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _context.Produtos.FindAsync(id);
            if (existing == null) return NotFound();

            _context.Produtos.Remove(existing);
            await _context.SaveChangesAsync();
            return NoContent();
            }
    }
}