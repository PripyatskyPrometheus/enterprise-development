# Система бронирования отелей

## Задание
Реализовать структуру классов, описывающих предметную область, определяемую в задании. В каждом из заданий присутствует часть, связанная с обработкой данных, представленная в разделе «Запросы». Данную часть необходимо реализовать в виде unit-тестов: подготовить тестовые данные, выполнить запрос с использованием LINQ, проверить результаты.

## Классы

### ArmoredRoom
Содержит информацию о бронированных комнатах: клиент, комната, дата заселения и дата выселения и период проживания.

### Client
Содержит информацию о клиенте: индентификатор, имя, паспортные данные и дата рождения.

### Hotel
Содержит информацию об отеле: идентификатор, название, адрес и город.

### Pasport
Содержит пасспортные данные клиента: индентификатор, серия и номер.

### Room
Содержит информацию о комнате: идентификатор, тип комнаты, вместимость, стоимость и идентификатор отеля. 

### TypeRoom
Содержит информацию о типах комнат: индентификатор и название типа.

## Тесты

### ReturnAllHotels
Тест на вывод сведений об отелях.

### ReturnAllClientInHotel
Тест на вывод сведений о клиентах, проживающих в отеле.

### ReturnTopFiveHotel
Тест на вывод топа отелей по наибольшему числу бронирований.

### ReturnFreeRooms
Тест на вывод сведений о свободных к бронированию комнат в выбраном городе

### returnLongLiversHotel
Тест на вывод сведений о клиентах, занявших номера на наиболее длительный срок.

### minAvgMaxCostInHotel
Тест на вывод сведений о минимальной, максимальной и средней ценах комнат для каждого отеля