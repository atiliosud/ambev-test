# Desafio Desenvolvedor Senior - AmbevTech

## Visão Geral

Este projeto consiste na criação de uma API para gerenciar revendas da Ambev e permitir a emissão de pedidos de bebidas para clientes finais. O objetivo é simular um fluxo de pedidos de bebidas de forma estruturada.

## Funcionalidades

1. **Cadastro de Revendas**

   - Cadastro completo de revendas com os seguintes campos obrigatórios:
     - CNPJ (validado)
     - Razão Social (validado)
     - Nome Fantasia (opcional)
     - Email (validado)
     - Telefone (opcional, múltiplos telefones permitidos)
     - Nome do Contato (múltiplos nomes permitidos, mas deve haver um principal)
     - Endereço de Entrega (múltiplos endereços permitidos)

2. **Recebimento de Pedidos**

   - API para receber pedidos dos clientes da revenda.
   - Considerações:
     - A revenda deve ser autenticada
     - O limite de produtos deve respeitar quantidades predefinidas
     - O pedido deve conter uma identificação e lista de itens solicitados
     - Nenhum pedido pode ser registrado com quantidade zero

3. **Emissão de Pedidos para AMBEV**

   - Integração via serviço REST da AMBEV para envio dos pedidos
   - Restrições:
     - A AMBEV só reconhece pedidos de revendas cadastradas
     - O pedido não pode exceder 1000 unidades
     - A API da AMBEV responde com status de aceite/rejeição
     - Regras de reenvio automático para pedidos pendentes ou rejeitados

## Tecnologias Utilizadas

- **Back-end:** .NET mais recente, SQLite para armazenamento dos dados
- **API:** RESTful
- **Banco de Dados:** SQLite
- **Integração:** API REST da AMBEV
