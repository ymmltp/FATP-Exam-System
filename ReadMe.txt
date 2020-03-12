User Level:
1、Power User:In poweruser list,without exam type, those who can create new exam(can view _blank select)can view all exam info
2、Admin User:In a exist exam,those who can only manage the exam he select when log in(add students and add question)
3、User:those who can join exam,can't visit the setting select 


Database:
1、department/project/poweruser   //select insert delete
2、examconfig/questionlist/userlist  //select insert update delete
  (database 2 update 2019.12.09:
  each table have a ID.
  WHEN SELECT CREATE AN IndexID,Invisible the exist ID AND show the indexID.
  when update and delete using the exist ID)
3、examscore  //select  using replace instead of update and insert  delete


WebFrom:
1、LogIn:    V
  Select User,transport to ExamForm(Can only view the exam from);
  Select Admin/_blank(Power) also transport to examconfig (can view all web from) 
2、Department/Project   V
3、Exam     V
4、SetExam   V
5、SetUser   V
6、SetQuestion   V
7、ExamScore   V
8、批量上传
9、通用ID,给没有NTID的用户   V
10、ScoreSearch 添加总分列，及格绿色，不及格红色  V
11、ScoreSearch添加个人查询。（加载ScoreSearch页面，判断是否是管理员，如果不是，将ntid写死）V

12、添加考试人员后直接发邮件通知


Question:
1、Log In按钮：如果初次点击不跳转，多次点击时就会报错  
2、Set Question界面：Question Type的选择，无法限制answer的可选个数

题目录入：
69-71
92-96 没有录入
