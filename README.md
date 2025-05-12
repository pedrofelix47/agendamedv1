# 🩺 AgendaMed API

AgendaMed é uma API RESTful desenvolvida em C# (.NET) para gerenciar **agendamentos de consultas médicas**, com controle de **especialidades, convênios, horários disponíveis, agendamentos e atendimentos**.

---

## 🚀 Como executar

### ✅ Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) instalado (.NET 7 ou superior)

### ▶️ Executando localmente

```bash
git clone https://github.com/seu-usuario/AgendaMed.git
cd AgendaMed
dotnet build
dotnet run
```

A aplicação estará disponível por padrão em `http://localhost:5000`.

---

## 📦 Estrutura do Projeto

```
AgendaMed/
├── Controllers/
├── Models/
├── DTOs/
├── Repositories/
├── Services/
├── Program.cs
└── README.md
```

---

## 📚 API - Endpoints

### 🏥 Especialidades

#### ➕ Cadastrar
`POST /api/especialidades`

```json
{
  "nome": "Cardiologia"
}
```

#### 📄 Listar
`GET /api/especialidades`

---

### 💳 Convênios

#### ➕ Cadastrar
`POST /api/convenios`

```json
{
  "nome": "Unimed"
}
```

#### 📄 Listar
`GET /api/convenios`

---

### ⏰ Disponibilidades

#### ➕ Definir disponibilidade
`POST /api/disponibilidades/definir`

```json
{
  "medico": "Dra. Maria Silva",
  "especialidadeId": 1,
  "diaSemana": "Segunda-feira",
  "horaInicio": "08:00",
  "horaFim": "12:00",
  "duracaoConsultaMinutos": 30
}
```

#### 📅 Listar horários disponíveis
`POST /api/disponibilidades`

```json
{
  "especialidadeId": 1,
  "data": "2025-05-12",
  "medico": "Dra. Maria Silva"
}
```

---

### 📆 Agendamentos

#### ➕ Agendar consulta
`POST /api/agendamentos`

```json
{
  "paciente": "João da Silva",
  "especialidadeId": 1,
  "convenioId": 1,
  "dataHora": "2025-05-12T08:00:00Z"
}
```

#### 📄 Listar agendamentos
`GET /api/agendamentos?dataInicio=2025-05-10&dataFim=2025-05-13&paciente=João`

---

### 🩺 Atendimentos

#### ➕ Gerar atendimento
`POST /api/atendimentos`

```json
{
  "agendamentoId": 1,
  "observacoes": "Paciente apresentou dor no peito leve."
}
```

#### 📄 Listar atendimentos
`GET /api/atendimentos?dataInicio=2025-05-10&dataFim=2025-05-13&paciente=João`

---

## ✅ Requisitos Atendidos

- [x] API RESTful com ASP.NET
- [x] Controle de Especialidades e Convênios
- [x] Agendamento com validação de disponibilidade
- [x] Controle de atendimentos
- [x] Repositórios e Services organizados
- [x] Validações e boas práticas de código

