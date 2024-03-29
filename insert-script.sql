USE [ThesisDb]
GO
INSERT [dbo].[authors] ([author_id], [author_name], [author_surname], [author_age]) VALUES (N'12345678901', N'John', N'Doe', 25)
INSERT [dbo].[authors] ([author_id], [author_name], [author_surname], [author_age]) VALUES (N'23456789012', N'Jane', N'Smith', 30)
INSERT [dbo].[authors] ([author_id], [author_name], [author_surname], [author_age]) VALUES (N'34567890123', N'Bob', N'Johnson', 28)
INSERT [dbo].[authors] ([author_id], [author_name], [author_surname], [author_age]) VALUES (N'45678901234', N'Dave', N'Maguire', 35)
INSERT [dbo].[authors] ([author_id], [author_name], [author_surname], [author_age]) VALUES (N'56789012345', N'Brain', N'May', 51)
GO
INSERT [dbo].[co_supervisors] ([co_sup_id], [co_sup_name], [co_sup_surname], [co_sup_age]) VALUES (N'12345678901', N'Jacop', N'Tall', 45)
INSERT [dbo].[co_supervisors] ([co_sup_id], [co_sup_name], [co_sup_surname], [co_sup_age]) VALUES (N'23456789012', N'Julia', N'Garnov', 49)
INSERT [dbo].[co_supervisors] ([co_sup_id], [co_sup_name], [co_sup_surname], [co_sup_age]) VALUES (N'34567890123', N'Sara', N'Smirnov', 34)
GO
INSERT [dbo].[supervisors] ([sup_id], [sup_name], [sup_surname], [sup_age]) VALUES (N'12345543211', N'Lewis', N'Hamilton', 45)
INSERT [dbo].[supervisors] ([sup_id], [sup_name], [sup_surname], [sup_age]) VALUES (N'12345543212', N'Max', N'Verstappen', 39)
INSERT [dbo].[supervisors] ([sup_id], [sup_name], [sup_surname], [sup_age]) VALUES (N'12345543213', N'Sebastian', N'Vettel', 44)
INSERT [dbo].[supervisors] ([sup_id], [sup_name], [sup_surname], [sup_age]) VALUES (N'12345543214', N'Charles', N'Leclerc', 45)
INSERT [dbo].[supervisors] ([sup_id], [sup_name], [sup_surname], [sup_age]) VALUES (N'12345543215', N'Kimi', N'Raikkonen', 43)
GO
SET IDENTITY_INSERT [dbo].[university] ON 

INSERT [dbo].[university] ([uni_id], [uni_name], [uni_address]) VALUES (1, N'Maltepe Üniversitesi', N'Istanbul')
INSERT [dbo].[university] ([uni_id], [uni_name], [uni_address]) VALUES (2, N'Gazi Üniversitesi', N'Ankara')
INSERT [dbo].[university] ([uni_id], [uni_name], [uni_address]) VALUES (3, N'Katip Çelebi Üniversitesi', N'Izmir')
INSERT [dbo].[university] ([uni_id], [uni_name], [uni_address]) VALUES (4, N'Akdeniz Üniversity', N'Antalya')
INSERT [dbo].[university] ([uni_id], [uni_name], [uni_address]) VALUES (5, N'Istanbul Teknik Üniversitesi', N'Istanbul')
SET IDENTITY_INSERT [dbo].[university] OFF
GO
SET IDENTITY_INSERT [dbo].[institutes] ON 

INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (1, N'Mühendislik ve Doga Bilimleri', 1)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (2, N'Hukuk Fakültesi', 1)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (3, N'Egitim Bilimleri Fakültesi', 1)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (4, N'Mühendislik Fakültesi', 2)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (5, N'Hukuk Fakültesi', 2)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (6, N'Egitim Fakültesi', 2)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (7, N'Fen-Edebiyat Fakültesi', 2)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (8, N'Tip Fakültesi', 1)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (9, N'Tip Fakültesi', 3)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (10, N'Uçak ve Uzay Bilimleri Fakültesi', 5)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (11, N'Makine Fakültesi', 5)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (12, N'Bilgisayar ve Bilisim Fakültesi', 5)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (13, N'Fen-Edebiyat Fakültesi', 5)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (14, N'Eczacilik Fakültesi', 3)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (15, N'Edebiyat Fakültesi', 4)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (16, N'Egitim Fakültesi', 4)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (17, N'Ziraat Fakültesi', 4)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (18, N'Mühendislik Fakültesi', 4)
INSERT [dbo].[institutes] ([ins_id], [ins_name], [uni_id]) VALUES (19, N'Mühendislik Fakültesi', 3)
SET IDENTITY_INSERT [dbo].[institutes] OFF
GO
SET IDENTITY_INSERT [dbo].[thesis] ON 

INSERT [dbo].[thesis] ([thesis_no], [title], [abstract], [author_id], [type], [uni_id], [ins_id], [num_pages], [language], [submission_date], [sup_id], [co_sup_id]) VALUES (1000000, N'Applications of Nanotechnology in Medicine', N'This thesis explores the transformative applications of nanotechnology in medicine. Focusing on the nanoscale, it investigates the potential impact on medical diagnostics and treatment. Beginning with fundamental nanotechnology principles, the study emphasizes nanoscale materials'' role in targeted drug delivery, imaging, and diagnostics. Synthesis and design of nanocarriers for drug delivery are examined for enhanced therapeutic efficacy. The use of nanotechnology in imaging modalities is explored, highlighting contrast agent development for improved resolution. Ethical considerations and challenges associated with nanotechnology in medicine are addressed. The research contributes insights to the scientific community, fostering a deeper understanding of nanotechnology''s promise in healthcare. In summary, this thesis unravels the intersections between nanotechnology and medicine, paving the way for innovative advancements in medical science.', N'34567890123', N'Specialization in Medicine', 1, 1, 250, N'Spanish', CAST(N'2021-12-10' AS Date), N'12345543212', NULL)
INSERT [dbo].[thesis] ([thesis_no], [title], [abstract], [author_id], [type], [uni_id], [ins_id], [num_pages], [language], [submission_date], [sup_id], [co_sup_id]) VALUES (1000001, N'Enhancing Online Learning Environments: A Comprehensive Study on User Engagement', N'This doctoral thesis addresses the evolving landscape of education by investigating strategies to enhance user engagement in online learning environments. The research employs a multi-dimensional approach, analyzing the impact of instructional design, technological interventions, and learner-centered strategies on student engagement and academic performance. The findings contribute valuable insights to educators, institutions, and policymakers aiming to optimize the effectiveness of online education platforms.', N'23456789012', N'Doctorate', 2, 6, 150, N'French', CAST(N'2023-02-20' AS Date), N'12345543211', N'23456789012')
INSERT [dbo].[thesis] ([thesis_no], [title], [abstract], [author_id], [type], [uni_id], [ins_id], [num_pages], [language], [submission_date], [sup_id], [co_sup_id]) VALUES (1000002, N'Precision Agriculture: Integrating Technology for Sustainable Crop Management', N'This mastery’s thesis explores the application of precision agriculture techniques to enhance the sustainability and efficiency of crop management. The research investigates the integration of technologies such as sensors, drones, and data analytics to optimize farming practices. Through field experiments and data analysis, the study assesses the impact on resource utilization, crop yield, and environmental sustainability. The findings provide valuable insights for farmers and agricultural stakeholders seeking innovative approaches to modernize and improve farming practices.', N'45678901234', N'Master', 4, 17, 200, N'German', CAST(N'2018-11-14' AS Date), N'12345543214', N'34567890123')
INSERT [dbo].[thesis] ([thesis_no], [title], [abstract], [author_id], [type], [uni_id], [ins_id], [num_pages], [language], [submission_date], [sup_id], [co_sup_id]) VALUES (1000003, N'Exploring Sustainable Urban Development through Smart Infrastructure Implementation', N'This master''s thesis investigates the integration of smart infrastructure to achieve sustainable urban development. Focused on leveraging technology for improved resource efficiency and quality of life, the study explores key facets such as energy management, transportation systems, and waste reduction. Through case studies and data analysis, the research aims to provide practical insights for urban planners and policymakers. The findings contribute to the discourse on building smarter, more sustainable cities, emphasizing the role of technology in addressing contemporary urban challenges. This exploration into smart infrastructure''s impact on urban sustainability lays the foundation for informed decision-making in future urban development initiatives', N'12345678901', N'Master', 3, 19, 100, N'English', CAST(N'2016-06-16' AS Date), N'12345543211', N'12345678901')
INSERT [dbo].[thesis] ([thesis_no], [title], [abstract], [author_id], [type], [uni_id], [ins_id], [num_pages], [language], [submission_date], [sup_id], [co_sup_id]) VALUES (1000004, N'Unraveling the Complexity of Human-Computer Interaction: A Multidimensional Analysis', N'This doctoral thesis delves into the intricate landscape of human-computer interaction (HCI), aiming to unravel its multidimensional nature. By employing advanced research methodologies and cutting-edge technology, the study explores not only the cognitive aspects but also emotional and social dimensions of HCI. Through a series of experiments and in-depth analyses, the research contributes to a nuanced understanding of user experience and interface design. The findings have implications for the development of more intuitive and user-centric computing systems. This comprehensive investigation into the complexities of HCI serves as a significant advancement in the field, paving the way for future innovations in human-centered computing.', N'12345678901', N'Doctorate', 5, 10, 170, N'English', CAST(N'2023-10-05' AS Date), N'12345543213', NULL)
INSERT [dbo].[thesis] ([thesis_no], [title], [abstract], [author_id], [type], [uni_id], [ins_id], [num_pages], [language], [submission_date], [sup_id], [co_sup_id]) VALUES (1000005, N'AI New Thesis', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas posuere dictum massa ut fermentum. Aliquam a eros egestas, venenatis velit quis, suscipit enim. Morbi dictum, purus vitae ullamcorper commodo, sapien libero mollis turpis, sed varius lorem magna ut tortor. Ut ut est ipsum. In lacinia risus sem, eu congue lectus lobortis in. Proin neque velit, ultrices quis egestas ut, dictum eu sapien. Nunc efficitur auctor nulla, vitae vehicula lacus aliquet eu. Curabitur eu justo euismod, fermentum eros a, molestie lorem. Maecenas id nisi porttitor, porta tellus sit amet, egestas quam. Integer porta condimentum tincidunt. Morbi id auctor massa, nec laoreet lorem. Quisque vestibulum condimentum sapien, at tincidunt nisi sagittis in. Fusce eu arcu pellentesque, efficitur arcu sit amet, pretium turpis. Suspendisse justo sapien, finibus a risus sit amet, sodales molestie augue. Ut interdum augue in euismod dignissim.

Sed tempor ullamcorper sollicitudin. Mauris sed rutrum mi. Sed commodo volutpat laoreet. Fusce porttitor a ligula eget sollicitudin. Mauris vehicula sed nulla sit amet malesuada. Morbi leo lacus, sollicitudin id consectetur eu, imperdiet eget enim. Sed eget commodo ipsum, quis elementum dolor. Aenean aliquam dignissim nisi, et imperdiet lacus volutpat at. Pellentesque eros nisl, varius eget eros id, porta ultrices est. Pellentesque bibendum, risus ut dictum ultrices, est neque elementum quam, vel cursus leo quam et nisl. Cras sollicitudin ornare ex, ut porta erat tristique ut. Nunc sed placerat eros.', N'45678901234', N'Master', 1, 1, 1024, N'English', CAST(N'2024-01-07' AS Date), N'12345543213', N'34567890123')
SET IDENTITY_INSERT [dbo].[thesis] OFF
GO
INSERT [dbo].[subject_topics] ([st_id], [st_name]) VALUES (1, N'Exploring Artificial Intelligence in Healthcare')
INSERT [dbo].[subject_topics] ([st_id], [st_name]) VALUES (2, N'Neuroscience and Cognitive Computing')
INSERT [dbo].[subject_topics] ([st_id], [st_name]) VALUES (3, N'Artificial Intelligence in Visual Arts')
INSERT [dbo].[subject_topics] ([st_id], [st_name]) VALUES (4, N'Applications of Nanotechnology in Medicine')
INSERT [dbo].[subject_topics] ([st_id], [st_name]) VALUES (5, N'Advancements in Renewable Energy Technologies')
GO
INSERT [dbo].[t_subjects] ([id], [thesis_no], [st_id]) VALUES (1, 1000001, 1)
INSERT [dbo].[t_subjects] ([id], [thesis_no], [st_id]) VALUES (2, 1000001, 2)
INSERT [dbo].[t_subjects] ([id], [thesis_no], [st_id]) VALUES (3, 1000000, 3)
INSERT [dbo].[t_subjects] ([id], [thesis_no], [st_id]) VALUES (4, 1000002, 4)
INSERT [dbo].[t_subjects] ([id], [thesis_no], [st_id]) VALUES (5, 1000003, 5)
INSERT [dbo].[t_subjects] ([id], [thesis_no], [st_id]) VALUES (6, 1000005, 5)
INSERT [dbo].[t_subjects] ([id], [thesis_no], [st_id]) VALUES (7, 1000005, 3)
INSERT [dbo].[t_subjects] ([id], [thesis_no], [st_id]) VALUES (8, 1000005, 1)
INSERT [dbo].[t_subjects] ([id], [thesis_no], [st_id]) VALUES (9, 1000004, 2)
GO
INSERT [dbo].[keywords] ([key_id], [key_name], [thesis_no]) VALUES (1, N'medicine', 1000004)
INSERT [dbo].[keywords] ([key_id], [key_name], [thesis_no]) VALUES (2, N'ai', 1000002)
INSERT [dbo].[keywords] ([key_id], [key_name], [thesis_no]) VALUES (3, N'science', 1000000)
INSERT [dbo].[keywords] ([key_id], [key_name], [thesis_no]) VALUES (4, N'learning', 1000003)
INSERT [dbo].[keywords] ([key_id], [key_name], [thesis_no]) VALUES (5, N'bussines', 1000001)
INSERT [dbo].[keywords] ([key_id], [key_name], [thesis_no]) VALUES (6, N'software', 1000003)
INSERT [dbo].[keywords] ([key_id], [key_name], [thesis_no]) VALUES (7, N'AI', 1000005)
INSERT [dbo].[keywords] ([key_id], [key_name], [thesis_no]) VALUES (8, N'Visual Arts', 1000005)
INSERT [dbo].[keywords] ([key_id], [key_name], [thesis_no]) VALUES (9, N'Energy', 1000005)
INSERT [dbo].[keywords] ([key_id], [key_name], [thesis_no]) VALUES (10, N'Health', 1000005)
GO
