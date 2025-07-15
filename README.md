# 📬 Queue Strukturları (FIFO) – `MyQueue<T>` və `CircularQueue<T>`

Bu bölmədə iki növ Queue (növbə) strukturu təqdim olunur:

1. `MyQueue<T>` – klassik lineer massiv əsaslı növbə
2. `CircularQueue<T>` – dairəvi (circular buffer) əsaslı növbə

Hər iki struktur FIFO (First-In, First-Out — İlk daxil olan, ilk çıxır) prinsipinə əsaslanır. Yəni əlavə olunan elementlər sırayla çıxarılır.

---

## 1️⃣ `MyQueue<T>` – Klassik Növbə

**Fayl:** `StackQueue/MyQueue.cs`

### 🔍 Qısa izah:
`MyQueue<T>` sadə massiv üzərində qurulmuş növbə strukturudur. Yeni elementlər `tail` indeksindən əlavə olunur, silinmə isə `head` indeksindən həyata keçirilir.

### 🧠 İş prinsipi:
- Əgər massiv doludursa, `Extend()` ilə ölçüsü artırılır.
- Əgər element sayı 1/4 qədər azalıbsa, `Shrink()` ilə ölçü azaldılır.
- Yaddaş istifadəsini balanslaşdırmaq üçün avtomatik genişlənmə və kiçilmə tətbiq edilir.

### 🔧 Əsas metodlar:

| Metod         | Açıqlama                                               |
|---------------|---------------------------------------------------------|
| `Enqueue(T)`  | Yeni elementi növbənin sonuna əlavə edir                |
| `Dequeue()`   | Növbənin əvvəlindəki elementi silir və qaytarır         |
| `IsEmpty()`   | Növbənin boş olub olmadığını yoxlayır (`true/false`)    |

### 🧪 İstifadə nümunəsi:

```csharp
var queue = new MyQueue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
Console.WriteLine(queue.Dequeue()); // 1
Console.WriteLine(queue.Dequeue()); // 2

ℹ️ Əlavə Qeydlər:
Extend() metodu köhnə massivdəki elementləri yeni və daha böyük massivə köçürür.

Shrink() isə boşluq itkisinin qarşısını almaq üçün yaddaşı azaldır.

head və tail indeksləri sıralama pozulmasın deyə yenidən hesablanır.
2️⃣ CircularQueue<T> – Dairəvi Növbə
Fayl: StackQueue/CircularQueue.cs

🔍 Qısa izah:
CircularQueue<T> — dairəvi tampon (circular buffer) üzərində qurulmuş növbə strukturudur. Əlavə və silmə əməliyyatlarında mod (%) operatorundan istifadə edilir ki, indekslər 0–N aralığında qalsın və təkrarlana bilsin.

🧠 İş prinsipi:
tail indeksinə yeni element yazılır, sonra (tail + 1) % capacity ilə bükülür.

head indeksindən element çıxarılır, (head + 1) % capacity ilə yenilənir.

Əgər massiv dolu olarsa, Extend() ilə ölçü artırılır və bütün elementlər yeni massivə düzgün sıra ilə köçürülür.
🔧 Əsas metodlar:
| Metod         | Açıqlama                                               |
|---------------|---------------------------------------------------------|
| `Enqueue(T)`  | Yeni elementi növbənin sonuna əlavə edir                |
| `Dequeue()`   | Növbənin əvvəlindəki elementi silir və qaytarır         |
| `Peek()`   | Ən əvvəlki elementi silmədən qaytarır    |

### 🧪 İstifadə nümunəsi:
```csharp
var cQueue = new CircularQueue<string>();
cQueue.Enqueue("A");
cQueue.Enqueue("B");
Console.WriteLine(cQueue.Peek());    // A
Console.WriteLine(cQueue.Dequeue()); // A
Console.WriteLine(cQueue.Peek());    // B
