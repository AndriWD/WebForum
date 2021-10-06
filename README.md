# WebForum
Запуск проекту WebForum
<br/>
<p>Взаємодія з користувачем в WebForum відбувається за допомогою Idenity, що суттєво спрощує роботу з користувачем і дає змогу за необхідності значно розширити наявний функціонал веб-програми. Також Identity додає до програми вже реалізований контекст даних за допомогою базового класу IdentetyDbContext<T> та клас наслідник ApplicationDbContext, який ми використовуємо в нашій програмі. Ми додали до програми ініціалізатор БД - AppDbIntilizer, наслідує базовий клас DropCreateDatabaseAlways, що кожного разу перезаписує БД тестовими користувачами/темами/постами. Щоб користувачі зберігалися в БД після зупинки програми потрібно відключити ініціалізатор в файлі Global.asax.cs строку 21 Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());</p> 
<p>Також БД було додано безпосередньо в проект, щоб виключити будь-які можливі проблеми з її створенням на іншій локальній машині</p>
<ul>Тестові користувачі:
  <li>User1 {Login= "user1@gmail.com", Password="123aA8-1"}</li>
<li>User2 {Login= "user2@gmail.com", Password="123aA8-2"}</li>
<li>User3 {Login= "user3@gmail.com", Password="123aA8-3"}</li>
<li>User4 {Login= "user4@gmail.com", Password="123aA8-4"}</li>
<li>User5 {Login= "user5@gmail.com", Password="123aA8-5"}</li>
  </ul>
