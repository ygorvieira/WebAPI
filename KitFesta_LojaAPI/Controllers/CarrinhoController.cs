using KitFesta_LojaAPI.DAO;
using KitFesta_LojaAPI.Models;
using System.Web.Http;

namespace KitFesta_LojaAPI.Controllers
{
    public class CarrinhoController : ApiController
    {
        public string GetCarrinho(int id)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            Carrinho carrinho = dao.Busca(id);

            return carrinho.ToXml();
        }
    }
}
