# PersonalAccount
В файле docker-compose.yml находятся переменные окружения:

backend-image:

  ConnectionStrings: - настройка строки подключения
  
postgres_image:

  POSTGRES_USER: - имя пользователя БД
  
  POSTGRES_PASSWORD: - пароль БД
  
  POSTGRES_DB: - название для БД
  
frontend-image:

  API_URL: - адрес бэка
  
Для сборки проекта необходимо из папки проекта выполнить команду:

**docker-compose build**

Запуск:

**docker-compose up**

Адрес: localhost:8082
