using AmbevTest.Data;
using AmbevTest.Domain.Entities;
using AmbevTest.Models.Revenda;
using Microsoft.EntityFrameworkCore;

namespace AmbevTest.Services
{
    public class RevendaService
    {
        private readonly ApplicationDbContext _db;

        public RevendaService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> CriarRevenda(CriarRevendaRequest request)
        {
            try
            {
                var revendas = await _db.Revendas.Where(x => x.CNPJ == request.CNPJ).CountAsync();

                if (revendas > 0)
                {
                    return $"{request.CNPJ} já cadastrado";
                }

                Revenda revenda = new Revenda()
                {
                    CNPJ = request.CNPJ,
                    Email = request.Email,
                    NomeFantasia = request.NomeFantasia,
                    RazaoSocial = request.RazaoSocial,
                };
                await _db.Revendas.AddAsync(revenda);
                await _db.SaveChangesAsync();

                int revendaId = revenda.Id;

                if (request.Telefones.Count > 0)
                {
                    foreach (var t in request.Telefones)
                    {
                        Telefone telefone = new Telefone()
                        {
                            Numero = t,
                            RevendaId = revendaId,
                        };

                        await _db.Telefones.AddAsync(telefone);
                    }
                    await _db.SaveChangesAsync();
                }

                var contatosPrincipais = request.Contatos.Count(c => c.Principal);
                if (contatosPrincipais > 1)
                {
                    return "Escolha apenas um contato como principal";
                }

                if (request.Contatos.Count > 0)
                {
                    foreach (var c in request.Contatos)
                    {
                        Contato contato = new Contato()
                        {
                            Nome = c.Nome,
                            Principal = c.Principal,
                            RevendaId = revendaId,
                        };

                        await _db.Contatos.AddAsync(contato);
                    }
                    await _db.SaveChangesAsync();
                }

                if (request.EnderecosDeEntrega.Count > 0)
                {
                    foreach (var e in request.EnderecosDeEntrega)
                    {
                        Endereco endereco = new Endereco()
                        {
                            Bairro = e.Bairro,
                            Cep = e.Cep,
                            Cidade = e.Cidade,
                            Estado = e.Estado,
                            Numero = e.Numero,
                            Rua = e.Rua,
                            RevendaId = revendaId,
                        };

                        await _db.Enderecos.AddAsync(endereco);
                    }
                    await _db.SaveChangesAsync();
                }

                return "Cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar revenda: {ex.Message}");
                return "Ocorreu um erro";
            }
        }

        public async Task<RetornoRevenda> BuscarRevendaPorID(int revendaId)
        {
            try
            {
                var query = from r in _db.Revendas
                            join e in _db.Enderecos on r.Id equals e.RevendaId
                            join t in _db.Telefones on r.Id equals t.RevendaId
                            join c in _db.Contatos on r.Id equals c.RevendaId
                            where r.Id == revendaId
                            select new
                            {
                                Revenda = r,
                                Endereco = e,
                                Telefone = t,
                                Contato = c,
                            };

                var resultados = await query.ToListAsync();

                if (resultados == null || !resultados.Any())
                {
                    return null; 
                }

                var retornoRevenda = new RetornoRevenda
                {
                    Id = resultados.First().Revenda.Id,
                    CNPJ = resultados.First().Revenda.CNPJ,
                    RazaoSocial = resultados.First().Revenda.RazaoSocial,
                    NomeFantasia = resultados.First().Revenda.NomeFantasia,
                    Email = resultados.First().Revenda.Email,
                    Telefones = resultados.Select(x => new Telefone
                    {
                        Id = x.Telefone.Id,
                        RevendaId = x.Revenda.Id,
                        Numero = x.Telefone.Numero
                    }).Distinct().ToList(),
                    EnderecosEntrega = resultados.Select(x => new Endereco
                    {
                        Id = x.Endereco.Id,
                        RevendaId = x.Revenda.Id,
                        Rua = x.Endereco.Rua,
                        Numero = x.Endereco.Numero,
                        Bairro = x.Endereco.Bairro,
                        Cidade = x.Endereco.Cidade,
                        Estado = x.Endereco.Estado,
                        Cep = x.Endereco.Cep
                    }).Distinct().ToList(),
                    NomesContato = resultados.Select(x => new Contato
                    {
                        Id = x.Contato.Id,
                        RevendaId = x.Revenda.Id,
                        Nome = x.Contato.Nome,
                        Principal = x.Contato.Principal,

                    }).Distinct().ToList()
                };

                return retornoRevenda;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar revenda: {ex.Message}");
                return new RetornoRevenda(); 
            }
        }
    }
}
