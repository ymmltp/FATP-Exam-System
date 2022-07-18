# FATP-Exam-System

## Design

### User Level

1、Power User:In poweruser list,without exam type, those who can create new exam(can view _blank select)can view all exam info
2、Admin User:In a exist exam,those who can only manage the exam he select when log in(add students and add question)
3、User:those who can join exam,can't visit the setting select

### Database

1、department/project/poweruser   //select insert delete
2、examconfig/questionlist/userlist  //select insert update delete
  (database 2 update 2019.12.09:
  each table have a ID.
  WHEN SELECT CREATE AN IndexID,Invisible the exist ID AND show the indexID.
  when update and delete using the exist ID)
3、examscore  //select  using replace instead of update and insert  delete

### WebFrom

- [x] LogIn   
  Select User,transport to ExamForm(Can only view the exam from);
  Select Admin/_blank(Power) also transport to examconfig (can view all web from)
- [x] Department/Project
- [x] Exam
- [x] SetExam
- [x] SetUser
- [x] SetQuestion
- [x] ExamScore
- [ ] 批量上传
- [x] 通用ID,给没有NTID的用户
- [x] ScoreSearch 添加总分列，及格绿色，不及格红色
- [x] ScoreSearch添加个人查询。（加载ScoreSearch页面，判断是否是管理员，如果不是，将ntid写死)
- [x] 添加考试人员后直接发邮件通知

### Question:

- [x] Log In按钮：如果初次点击不跳转，多次点击时就会报错  
- [x] Set Question界面：Question Type的选择，无法限制answer的可选个数
- [x] 题目录入：69-71,92-96 没有录入

## New Demand and Update

### 2022.07.01 Update

- [x] 登录后填写考试人姓名
- [ ] 支持图片题
- [ ] 登陆后选择考试内容
