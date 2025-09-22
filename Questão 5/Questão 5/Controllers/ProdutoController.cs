using System.Collections.Generic;
using System.Linq;
using Questão_5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Questão_5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private static List<ProdutoDTO> _produtos = new List<ProdutoDTO>();

        [HttpGet("produtos")]
        public ActionResult<List<ProdutoDTO>> ObterProdutos()
        {
            return Ok(_produtos);
        }

        [HttpGet("produtos/{codigo}")]
        public ActionResult<ProdutoDTO> ObterProdutoPorCodigo(string codigo)
        {
            var produto = _produtos.FirstOrDefault(p => p.CodigoProduto == codigo);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            return Ok(produto);
        }

        [HttpPost("produtos")]
        public ActionResult CriarProduto([FromBody] ProdutoDTO novoProduto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(kvp => kvp.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new { message = "Erro na validação", errors });
            }

            _produtos.Add(novoProduto);
            return Ok("Produto criado com sucesso");
        }

        [HttpPut("produtos/{codigo}")]
        public ActionResult AtualizarProduto(string codigo, [FromBody] ProdutoDTO produtoAtualizado)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(kvp => kvp.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new { message = "Validação falhou", errors });
            }

            var produtoExistente = _produtos.FirstOrDefault(p => p.CodigoProduto == codigo);

            if (produtoExistente == null)
                return NotFound("Produto não encontrado.");

            produtoExistente.Descricao = produtoAtualizado.Descricao;
            produtoExistente.Preco = produtoAtualizado.Preco;
            produtoExistente.Estoque = produtoAtualizado.Estoque;
            produtoExistente.CodigoProduto = produtoAtualizado.CodigoProduto;

            return Ok("Produto atualizado com sucesso");
        }

        [HttpDelete("produtos/{codigo}")]
        public ActionResult DeleteProduto(string codigo)
        {
            var produtoExistente = _produtos.FirstOrDefault(p => p.CodigoProduto == codigo);

            if (produtoExistente == null)
                return NotFound("Produto não encontrado.");

            _produtos.Remove(produtoExistente);
            return NoContent();
        }
    }
}
