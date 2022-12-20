USE [desafio21diasapi]
GO

/****** Object:  Table [dbo].[tb_alunos]    Script Date: 19/12/2022 23:04:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_alunos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](150) NOT NULL,
	[matricula] [varchar](8) NOT NULL,
	[notas] [text] NOT NULL,
 CONSTRAINT [PK_tb_alunos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-----------------------------------------------------------------------------------------------------


USE [desafio21diasapi]
GO

/****** Object:  Table [dbo].[tb_fornecedores]    Script Date: 19/12/2022 23:05:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_fornecedores](
	[cod] [int] IDENTITY(1,1) NOT NULL,
	[nome_fantasia] [varchar](100) NOT NULL,
	[razao_social] [varchar](100) NULL,
	[cpf_cnpj] [varchar](20) NULL,
	[endereco] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


