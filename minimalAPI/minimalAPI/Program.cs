using Microsoft.EntityFrameworkCore;
using minimalAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllers();

// Configurar o Entity Framework Core com banco de dados em memória
builder.Services.AddDbContext<Banco>(options =>
    options.UseInMemoryDatabase("CadastroDb"));

// Adicionar documentação Swagger para facilitar testes
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();






/*
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Banco>(options =>
    options.UseInMemoryDatabase("CadastroDb"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/pessoas", async (Banco db, Pessoa pessoa) =>
{
    db.Pessoas.Add(pessoa);
    await db.SaveChangesAsync();
    return Results.Created($"/pessoas/{pessoa.Id}", pessoa);
});

app.MapPost("/enderecos", async (Banco db, Endereco endereco) =>
{
    var pessoa = await db.Pessoas.FindAsync(endereco.PessoaId);
    if (pessoa == null)
    {
        return Results.NotFound("Pessoa não encontrada.");
    }

    db.Enderecos.Add(endereco);
    await db.SaveChangesAsync();
    return Results.Created($"/enderecos/{endereco.Id}", endereco);
});

app.MapGet("/pessoas/{id}", async (Banco db, int id) =>
{
    var pessoa = await db.Pessoas.Include(p => p.Enderecos).FirstOrDefaultAsync(p => p.Id == id);
    return pessoa != null ? Results.Ok(pessoa) : Results.NotFound("Pessoa não encontrada.");
});

app.Run();

*/