# DỰ ÁN CỦA TÔI

## Message Broker
Một message broker là một ứng dụng chịu trách nhiệm trao đổi dữ liệu giữa các ứng dụng, hệ thống và dịch vụ, bất kể các ứng dụng đó được viết bằng ngôn ngữ khác nhau hoặc chạy trong các môi trường khác nhau.

Đặc biệt trong các hệ thống lớn, khi lưu lượng dữ liệu rất cao, các quy trình phải được sắp xếp theo một thứ tự nhất định vì khả năng của máy chủ bị giới hạn. Trong các hệ thống lớn, các ứng dụng mô-đun và độc lập cho phép giao tiếp thông qua việc nhắn tin sử dụng các thông điệp chuẩn đã được định trước. Điểm nghẽn có thể xảy ra trong giao tiếp với kiến trúc "không có broker". Giao tiếp giữa các ứng dụng không nên chạy theo cách làm chặn nhau. Vai trò của message broker ở lớp trung gian có thể vượt qua vấn đề này bằng cách xử lý các yêu cầu trong hàng đợi. Có nhiều message broker phổ biến như Azure Service Bus, Apache Kafka và RabbitMQ.
## RabbitMQ
RabbitMQ là một message broker cho việc nhắn tin. RabbitMQ hỗ trợ xử lý không đồng bộ. Nó cung cấp cho các ứng dụng một nền tảng chung để gửi và nhận tin nhắn, cũng như lưu trữ tin nhắn cho đến khi người tiêu dùng (consumer) sẵn sàng xử lý. RabbitMQ đơn giản chỉ lưu trữ các tin nhắn và chuyển chúng cho người tiêu dùng khi sẵn sàng.

## MassTransit
MassTransit là một service bus nhẹ để xây dựng các ứng dụng phân tán trên nền tảng .NET. Mục tiêu chính của nó là cung cấp một lớp trừu tượng nhất quán, thân thiện với .NET trên các phương thức truyền tải tin nhắn (dù là RabbitMQ, Azure Service Bus, v.v.)

### Một số khái niệm cơ bản cần biết:

- Service Bus: Thuật ngữ dùng để chỉ loại ứng dụng xử lý việc di chuyển các tin nhắn.
- Transports: Các loại message broker khác nhau mà MassTransit hỗ trợ.
- Message: Một hợp đồng được định nghĩa trước bằng cách tạo một lớp hoặc giao diện trong .NET.

### Một số lợi ích khi sử dụng MassTransit thay vì làm việc trực tiếp với thư viện của message broker gốc:
- Hỗ trợ nhiều message broker: MassTransit giúp các nhà phát triển làm việc với nhiều message broker mà không cần phải triển khai thêm vì nó trừu tượng hóa logic bên dưới của message broker, cho phép sử dụng chúng đồng thời trong cùng một môi trường hoặc khác nhau ở mỗi môi trường.
- Giải pháp tích hợp sẵn: MassTransit cung cấp các giải pháp tích hợp sẵn cho xử lý ngoại lệ, thử lại, circuit breaker, quản lý giao dịch phân tán, định tuyến, quản lý vòng đời người tiêu dùng, giám sát, v.v. Nhà phát triển không cần phải triển khai tất cả các tính năng này, tiết kiệm thời gian và giúp họ tập trung vào nhu cầu của dự án.
## Ví dụ Thực Tế
Tình huống ví dụ: Người dùng muốn nhận thông báo thông qua việc gọi một API. Chúng ta sẽ phát triển dự án notifier gồm hai ứng dụng: một producer API và một consumer console app. Cả hai ứng dụng sẽ được tạo bằng các template mặc định của Visual Studio 2022. Dự án sẽ sử dụng Docker Compose làm công cụ điều phối. Cả hai ứng dụng sẽ được docker hóa và RabbitMQ sẽ chạy trong Docker.

# Cách chạy dự án.
B1 : chạy docker để chạy rabbitMQ và các consumer (setting số lượng consumer trong docker-compose.yaml, với deploy:
  replicas: 5 , mặc định tôi đang để 5 consumer)

`docker-compose up --build`

B2 : chạy http://localhost:15672/ để bật RabbitMQ management.

B3 : Đăng nhập tài khoản và mật khẩu đều là `guest`.

B4 : chạy dự án lên với `Set as startup Project` cho project `MasstransitRabbitMQ-Sample.Produces.API` để có thể tạo ra một produces có thể gửi `message` đến `RabbitMQ`




