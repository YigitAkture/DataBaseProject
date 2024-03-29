USE [ThesisDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authors](
	[author_id] [varchar](11) NOT NULL,
	[author_name] [varchar](50) NULL,
	[author_surname] [varchar](50) NULL,
	[author_age] [smallint] NULL,
 CONSTRAINT [PK_authors] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[co_supervisors](
	[co_sup_id] [varchar](11) NOT NULL,
	[co_sup_name] [varchar](100) NOT NULL,
	[co_sup_surname] [varchar](100) NOT NULL,
	[co_sup_age] [smallint] NOT NULL,
 CONSTRAINT [PK__co_super__CB64971F52E984BA] PRIMARY KEY CLUSTERED 
(
	[co_sup_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[institutes](
	[ins_id] [int] IDENTITY(1,1) NOT NULL,
	[ins_name] [varchar](100) NOT NULL,
	[uni_id] [int] NOT NULL,
 CONSTRAINT [PK__institut__9CB72D20BE7905B8] PRIMARY KEY CLUSTERED 
(
	[ins_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[keywords](
	[key_id] [int] NOT NULL,
	[key_name] [varchar](50) NOT NULL,
	[thesis_no] [int] NULL,
 CONSTRAINT [PK__keywords__97DF9ACD6DA19E79] PRIMARY KEY CLUSTERED 
(
	[key_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subject_topics](
	[st_id] [int] NOT NULL,
	[st_name] [varchar](200) NOT NULL,
 CONSTRAINT [PK__subject___A85E81CF42660A42] PRIMARY KEY CLUSTERED 
(
	[st_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supervisors](
	[sup_id] [varchar](11) NOT NULL,
	[sup_name] [varchar](100) NULL,
	[sup_surname] [varchar](100) NULL,
	[sup_age] [smallint] NULL,
 CONSTRAINT [PK__supervis__FB8F785F52102143] PRIMARY KEY CLUSTERED 
(
	[sup_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_subjects](
	[id] [int] NOT NULL,
	[thesis_no] [int] NULL,
	[st_id] [int] NULL,
 CONSTRAINT [PK_t_subjects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thesis](
	[thesis_no] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](500) NOT NULL,
	[abstract] [text] NOT NULL,
	[author_id] [varchar](11) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[uni_id] [int] NOT NULL,
	[ins_id] [int] NOT NULL,
	[num_pages] [int] NOT NULL,
	[language] [varchar](50) NOT NULL,
	[submission_date] [date] NOT NULL,
	[sup_id] [varchar](11) NULL,
	[co_sup_id] [varchar](11) NULL,
 CONSTRAINT [PK__thesis__50ACADFD0B7433F7] PRIMARY KEY CLUSTERED 
(
	[thesis_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[university](
	[uni_id] [int] IDENTITY(1,1) NOT NULL,
	[uni_name] [varchar](50) NOT NULL,
	[uni_address] [varchar](60) NOT NULL,
 CONSTRAINT [PK__universi__5D928CDE0B495EF1] PRIMARY KEY CLUSTERED 
(
	[uni_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[institutes]  WITH CHECK ADD  CONSTRAINT [FK__institute__uni_i__7F2BE32F] FOREIGN KEY([uni_id])
REFERENCES [dbo].[university] ([uni_id])
GO
ALTER TABLE [dbo].[institutes] CHECK CONSTRAINT [FK__institute__uni_i__7F2BE32F]
GO
ALTER TABLE [dbo].[keywords]  WITH CHECK ADD  CONSTRAINT [FK__keywords__thesis__0A9D95DB] FOREIGN KEY([thesis_no])
REFERENCES [dbo].[thesis] ([thesis_no])
GO
ALTER TABLE [dbo].[keywords] CHECK CONSTRAINT [FK__keywords__thesis__0A9D95DB]
GO
ALTER TABLE [dbo].[t_subjects]  WITH CHECK ADD  CONSTRAINT [FK__t_subject__st_id__10566F31] FOREIGN KEY([st_id])
REFERENCES [dbo].[subject_topics] ([st_id])
GO
ALTER TABLE [dbo].[t_subjects] CHECK CONSTRAINT [FK__t_subject__st_id__10566F31]
GO
ALTER TABLE [dbo].[t_subjects]  WITH CHECK ADD  CONSTRAINT [FK__t_subject__thesi__0F624AF8] FOREIGN KEY([thesis_no])
REFERENCES [dbo].[thesis] ([thesis_no])
GO
ALTER TABLE [dbo].[t_subjects] CHECK CONSTRAINT [FK__t_subject__thesi__0F624AF8]
GO
ALTER TABLE [dbo].[thesis]  WITH CHECK ADD  CONSTRAINT [FK__thesis__author_i__03F0984C] FOREIGN KEY([author_id])
REFERENCES [dbo].[authors] ([author_id])
GO
ALTER TABLE [dbo].[thesis] CHECK CONSTRAINT [FK__thesis__author_i__03F0984C]
GO
ALTER TABLE [dbo].[thesis]  WITH CHECK ADD  CONSTRAINT [FK__thesis__co_sup_i__07C12930] FOREIGN KEY([co_sup_id])
REFERENCES [dbo].[co_supervisors] ([co_sup_id])
GO
ALTER TABLE [dbo].[thesis] CHECK CONSTRAINT [FK__thesis__co_sup_i__07C12930]
GO
ALTER TABLE [dbo].[thesis]  WITH CHECK ADD  CONSTRAINT [FK__thesis__ins_id__05D8E0BE] FOREIGN KEY([ins_id])
REFERENCES [dbo].[institutes] ([ins_id])
GO
ALTER TABLE [dbo].[thesis] CHECK CONSTRAINT [FK__thesis__ins_id__05D8E0BE]
GO
ALTER TABLE [dbo].[thesis]  WITH CHECK ADD  CONSTRAINT [FK__thesis__sup_id__06CD04F7] FOREIGN KEY([sup_id])
REFERENCES [dbo].[supervisors] ([sup_id])
GO
ALTER TABLE [dbo].[thesis] CHECK CONSTRAINT [FK__thesis__sup_id__06CD04F7]
GO
ALTER TABLE [dbo].[thesis]  WITH CHECK ADD  CONSTRAINT [FK__thesis__uni_id__04E4BC85] FOREIGN KEY([uni_id])
REFERENCES [dbo].[university] ([uni_id])
GO
ALTER TABLE [dbo].[thesis] CHECK CONSTRAINT [FK__thesis__uni_id__04E4BC85]
GO
