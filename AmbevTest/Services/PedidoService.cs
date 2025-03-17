using AmbevTest.Domain.Entities;
using System.Text.Json;
using System.Text;
using AmbevTest.Models.Pedido;
using AmbevTest.Data;
using Microsoft.EntityFrameworkCore;

namespace AmbevTest.Services
{

    public class PedidoService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _db;

        public PedidoService(HttpClient httpClient, ApplicationDbContext db)
        {
            _httpClient = httpClient;
            _db = db;
        }

        public async Task<CriarPedidoResponse> CriarPedido(CriarPedidoRequest request)
        {
            CriarPedidoResponse response = new CriarPedidoResponse();

            try
            {
                int revendas = await _db.Revendas.Where(x => x.Id == request.RevendaId).CountAsync();

                if(revendas == 0)
                {
                    response.mensagem = "Revenda não cadastrada";
                    return response;
                }

                if (request.Items.Count == 0)
                {
                    response.mensagem = "Adicione pelo menos um item ao pedido";
                    return response;
                }

                Pedido novoPedido = new Pedido()
                {
                    RevendaId = request.RevendaId,
                    DataPedido = DateTime.Now
                };

                await _db.Pedidos.AddAsync(novoPedido);
                await _db.SaveChangesAsync();

                int novoPedidoId = novoPedido.Id;


                foreach (var item in request.Items)
                {
                    ItemPedido itemDoPedido = new ItemPedido()
                    {
                        PedidoId = novoPedidoId,
                        Produto = item.Produto,
                        Quantidade = item.Quantidade
                    };

                    await _db.ItensPedidos.AddAsync(itemDoPedido);
                    await _db.SaveChangesAsync();
                }

                response.mensagem = "Pedido cadastrado com sucesso";
                response.IdDoPedido = novoPedidoId;

                return response;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                response.mensagem = "Pedido cadastrado com sucesso";
                return response;

            }
        }

        
        public async Task<string> EnviarPedidoParaAmbev(int IdDoPedido)
        {

            try
            {
                var query = from p in _db.Pedidos
                            join i in _db.ItensPedidos on p.Id equals i.PedidoId
                            where p.Id == IdDoPedido
                            select new
                            {
                                Pedido = p,
                                Produtos = i,
                            };

                var resultados = await query.ToListAsync();

                if (resultados == null || !resultados.Any())
                {
                    return null;
                }


                var requestBody = JsonSerializer.Serialize(new
                {
                    revendaId = resultados.First().Pedido.RevendaId,
                    itens = resultados.Select(i => new { produto = i.Produtos.Produto, quantidade = i.Produtos.Quantidade })
                });

                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                int tentativas = 3;
                for (int i = 0; i < tentativas; i++)
                {
                    try
                    {
                        HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7083/api/mock-ambev/pedidos", content);
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                    }
                    catch (Exception)
                    {
                        await Task.Delay(2000);
                    }
                }

                return "Falha ao enviar pedido após várias tentativas.";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Falha ao enviar pedido após várias tentativas.";
            }

          
        } 

        
    }
}
