User Level:
1��Power User:In poweruser list,without exam type, those who can create new exam(can view _blank select)can view all exam info
2��Admin User:In a exist exam,those who can only manage the exam he select when log in(add students and add question)
3��User:those who can join exam,can't visit the setting select 


Database:
1��department/project/poweruser   //select insert delete
2��examconfig/questionlist/userlist  //select insert update delete
  (database 2 update 2019.12.09:
  each table have a ID.
  WHEN SELECT CREATE AN IndexID,Invisible the exist ID AND show the indexID.
  when update and delete using the exist ID)
3��examscore  //select  using replace instead of update and insert  delete


WebFrom:
1��LogIn:    V
  Select User,transport to ExamForm(Can only view the exam from);
  Select Admin/_blank(Power) also transport to examconfig (can view all web from) 
2��Department/Project   V
3��Exam     V
4��SetExam   V
5��SetUser   V
6��SetQuestion   V
7��ExamScore   V
8�������ϴ�
9��ͨ��ID,��û��NTID���û�   V
10��ScoreSearch ����ܷ��У�������ɫ���������ɫ  V
11��ScoreSearch��Ӹ��˲�ѯ��������ScoreSearchҳ�棬�ж��Ƿ��ǹ���Ա��������ǣ���ntidд����V

12����ӿ�����Ա��ֱ�ӷ��ʼ�֪ͨ


Question:
1��Log In��ť��������ε������ת����ε��ʱ�ͻᱨ��  
2��Set Question���棺Question Type��ѡ���޷�����answer�Ŀ�ѡ����

��Ŀ¼�룺
69-71
92-96 û��¼��
