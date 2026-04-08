WolverineFx paketinin Mediatr ve MassTransit yerine nasıl kullanılacağını gösteren demo projesi.
Transactional outbox ve inbox kavramlarını destekler.

Test etmek için docker ile rabbitmq ve mssql kurulabilir.
Demoda task apisine yapılan create ve delete işlemleri birer event fırlatır, bu event outbox tablosu üzerinden rabbitmq'ya iletilir ve yine bu proje içinde consume edilir.
