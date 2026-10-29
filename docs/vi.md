# Isometric Tiles — chế độ xem ô hình thoi

Isometric Tiles vẽ các bản đồ ô ở một góc nghiêng, thành lưới hình thoi 2:1, khiến nhà cửa và cây cối đứng dậy khỏi mặt đất. Đây là một trong hai chế độ xem bản đồ của nền chung Tile Rendering; chế độ kia là Top-down Tiles. Cùng các bản đồ, sự kiện và save đều chạy ở cả hai.

![Làng RPG Plus lúc trưa trong chế độ đẳng cự: quảng trường, đèn đường, nhà cửa, dân làng và nhân vật chính trên con đường; ngoài rìa bản đồ là nền trống.](assets/village-isometric.jpg)

## Khác gì so với chế độ nhìn từ trên

- **Ô hình thoi.** Mỗi ô được vẽ thành hình thoi rộng gấp đôi chiều cao. Lưới logic vẫn vuông: một ô vẫn có bốn ô kề như trước.
- **Vật thể đứng.** Nhà cửa và các vật thể nhiều ô mà tileset đánh dấu sẽ được vẽ như tranh dựng đứng hoặc vài mặt phẳng, thay vì ô phẳng.
- **Nhân vật** chọn hàng sprite khớp với hướng của mình trên lưới hình thoi.
- **Nhấp chuột** vào bản đồ sẽ chọn hình thoi dưới con trỏ; trình sửa bản đồ RPG dùng cùng luật đó.

![Cùng bản đồ làng ở hai chế độ: nhìn từ trên bên trái, đẳng cự bên phải.](assets/same-map-two-projections.jpg)

Không đổi: luật đi lại, va chạm, sự kiện, chiến đấu, save, chiếu sáng và thời gian trong ngày thuộc về mod RPG và Tile Rendering, hoạt động y hệt ở cả hai chế độ.

## Giới hạn

- **Phím theo lưới, không theo màn hình.** Lên và xuống (W/S, mũi tên) đi theo một đường chéo của màn hình, trái và phải theo đường chéo kia, vì chúng dịch nhân vật đúng một ô trên lưới vuông.
- **Rìa bản đồ bị lộ.** Gần góc bản đồ, bạn thấy nền trống ngoài mép hình thoi, như trong hình trên.
- **Tileset phải được chuẩn bị.** Vật thể chỉ đứng thẳng khi tileset mô tả chúng thành nhóm; ô thường được đặt phẳng trên các hình thoi.

## Cách bật

Trong sơ đồ game (**Mod & Bộ sưu tập → Bộ sưu tập → game → Sửa sơ đồ**), đưa mod này vào và đặt **Phép chiếu bản đồ** thành **Đẳng cự**. Giá trị của cài đặt `tile.renderer` là `isometric`:

```json
"settings": { "tile.renderer": "isometric" }
```

Muốn thử một lần mà không đổi game, hãy khởi động với `--tile-renderer=isometric` trên dòng lệnh. RPG Plus đã có sẵn cả hai trình kết xuất, nên chỉ cần đổi cài đặt.

## Khi có trục trặc

1. **Bản đồ trống trơn.** **Phép chiếu bản đồ** của game yêu cầu một trình kết xuất không có trong game; hãy đưa mod này vào hoặc chọn phép chiếu khác.
2. **Nhân vật đi chéo.** Phím hoạt động như vậy trong chế độ này (xem Giới hạn).
