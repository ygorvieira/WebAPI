﻿using KitFesta_LojaAPI.DAO;
using KitFesta_LojaAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KitFesta_LojaAPI.Controllers
{
    public class CarrinhoController : ApiController
    {
        public HttpResponseMessage GetCarrinho(int id)
        {
            try
            {
                var dao = new CarrinhoDAO();
                var carrinho = dao.Busca(id);

                return Request.CreateResponse(HttpStatusCode.OK, carrinho);
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("O carrinho {0} não foi localizado.", id);
                HttpError erro = new HttpError(mensagem);

                return Request.CreateResponse(HttpStatusCode.NotFound, erro);
            }
        }

        public HttpResponseMessage PostCarrinho([FromBody]Carrinho carrinho)
        {
            var dao = new CarrinhoDAO();
            dao.Adiciona(carrinho);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

            string location = Url.Link("DefaultApi", new { controller = "carrinho", id = carrinho.Id });

            response.Headers.Location = new Uri(location);

            return response;
        }

        [Route("api/carrinho/{idCarrinho}/produto/{idProduto}")]
        public HttpResponseMessage DeleteCarrinho([FromUri]int idCarrinho, [FromUri]int idProduto)
        {
            try
            {
                var dao = new CarrinhoDAO();
                var carrinho = dao.Busca(idCarrinho);
                carrinho.Remove(idProduto);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (KeyNotFoundException)
            {
                string mensagem = "Item não localizado";
                HttpError erro = new HttpError(mensagem);

                return Request.CreateResponse(HttpStatusCode.NotFound, erro);
            }

        }
    }
}
