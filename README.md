# Password Generator


Этот проект представляет собой мощный и гибкий генератор паролей


### Функционал:
1. Генерация случайных паролей:
    * Генерация пароля произвольной длины в заданных пределах (например, от 8 до 12 символов).
    * Возможность задания символов, которые могут быть использованы в пароле (allowedChars).
    * Возможность включения заглавных букв, строчных букв, цифр и специальных символов в пароли.
    * Поддержка частичного пароля, который может быть частично задан заранее, с заполнением оставшихся позиций случайными символами.
    * Приоритетное использование указанных символов в начале пароля (priorityChars).

2. Настройка символов:
    * Поддержка пользовательского набора символов для генерации пароля (allowedChars), который может включать буквы, цифры и специальные символы.
    * Возможность задания специальных символов, которые будут включены в пароль (specialChars).

3. Генерация множества паролей:
    * Поддержка массовой генерации паролей.
    * Все сгенерированные пароли сохраняются в указанный файл.

4. Измерение производительности:
    * Подсчет времени, затраченного на генерацию паролей.
    * Подсчет объема памяти, использованной при выполнении генерации паролей.

5. Вывод информации о процессе генерации:
    * Отображение параметров генерации перед началом процесса.
    * Вывод подробного отчета по завершении генерации, включая время выполнения и использование памяти.

6. Управление выводом:
    * Отображение информации о количестве сгенерированных паролей и месте их сохранения.
    * Уведомление пользователя о завершении процесса и запрос на завершение программы.


### Использование

**Установите на свой компьютер [.NET Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**

Для генерации паролей выполните программу с нужными параметрами. Пример использования:
```
int numberOfPasswords = 100;		// количество паролей
string filePath = "passwords.txt";      // файл куда сохранять пароли
int minLength = 8;			// минимальная длина пароля
int maxLength = 12;			// максимальная длина пароля

string allowedChars = "1q2wQwerty!;_";  // символы которые будут использоваться при генерации пароля
string partialPassword = "1q2w____";    // частичный ввод пароля ("_" означает пустое место)
string priorityChars = "1q2wQwerty!;_"; // приоритетные символы

bool useUpper = false;        		// использование заглавных букв
bool useLower = false;        		// использование строчных букв
bool useDigits = false;       		// использование цифр
bool useSpecialChars = false; 		// использование специальных символов

```

### Автор: provincialcxz
