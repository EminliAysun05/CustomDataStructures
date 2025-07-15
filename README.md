# 📬 Queue Strukturları (FIFO) – `MyQueue<T>` və `CircularQueue<T>`

Bu sənəddə iki fərqli Queue (növbə) strukturu izah olunur:

1. `MyQueue<T>` – Klassik lineer massiv əsaslı növbə
2. `CircularQueue<T>` – Dairəvi (circular buffer) əsaslı növbə

Hər iki struktur FIFO (First-In, First-Out — İlk daxil olan, ilk çıxır) prinsipinə əsaslanır.

---

## 🔹 `MyQueue<T>` – Klassik Növbə

📁 **Fayl:** `StackQueue/MyQueue.cs`

### 🔍 Təsviri
`MyQueue<T>` sadə massiv üzərində qurulmuş Queue implementasiyasıdır. Yeni elementlər `tail` indeksinə əlavə olunur, `head` indeksindən isə çıxarılır. Əlavə olaraq, Queue-nin ölçüsü dolduqda avtomatik genişlənir (`Extend()`), və element sayı 1/4-dən az olduqda yaddaşa qənaət üçün ölçü azaldılır (`Shrink()`).

### 🔧 Əsas metodlar

- `Enqueue(T item)` – Yeni element əlavə edir
- `Dequeue()` – Ən əvvəlki elementi silir və qaytarır
- `IsEmpty()` – Queue boş olub olmadığını yoxlayır

### 🧠 İş prinsipi

- **Genişlənmə:** Əgər Queue tam doludursa (`count == elements.Length`), `Extend()` metodu ilə ölçü ikiqat artırılır.
- **Kiçilmə:** Əgər Queue 4-də 1 qədər boşdursa (`count == elements.Length / 4`), `Shrink()` metodu çağırılır.
- `head` və `tail` indeksləri avtomatik köçürülür ki, elementlər ardıcıl qalsın.

### ✅ İstifadə nümunəsi

```csharp
var queue = new MyQueue<int>();
queue.Enqueue(10);
queue.Enqueue(20);
Console.WriteLine(queue.Dequeue()); // 10
Console.WriteLine(queue.Dequeue()); // 20
```
## 🔹 `CircularQueue<T>` – Dairəvi Növbə


📁 **Fayl:** `StackQueue/CircularQueue.cs`

### 🔍 Təsviri
`CircularQueue<T>` dairəvi tampon (circular buffer) əsaslı Queue strukturudur. `head` və `tail` indeksləri mod (`%`) operatoru ilə dairəvi şəkildə hərəkət edir. Bu sayədə boş sahələrdən səmərəli istifadə olunur və yaddaş itkisi minimuma endirilir.

### 🔧 Əsas metodlar

| Metod         | Açıqlama                                               |
|---------------|---------------------------------------------------------|
| `Enqueue(T)`  | Yeni elementi `tail` indeksinə əlavə edir              |
| `Dequeue()`   | `head` indeksindəki elementi silir və qaytarır         |
| `Peek()`      | `head`-dəki elementi silmədən qaytarır                 |
| `IsEmpty()`   | Queue boş olub olmadığını yoxlayır (`true` / `false`)  |

### 🧠 İş prinsipi

- **Dairəvi artım:**  
  `tail = (tail + 1) % capacity`  
  `head = (head + 1) % capacity`

- **Genişlənmə:**  
  Əgər Queue tam doludursa (`count == capacity`), `Extend()` metodu çağırılır.  
  Bu zaman `head`-dən başlayaraq elementlər yeni massivə köçürülür və indekslər sıfırlanır.

- **Yaddaş idarəsi:**  
  Circular yanaşma sayəsində massivdəki boşluqlardan səmərəli istifadə olunur.  
  `Shrink()` metoduna ehtiyac qalmır.

### ✅ İstifadə nümunəsi

```csharp
var cQueue = new CircularQueue<string>();
cQueue.Enqueue("A");
cQueue.Enqueue("B");

Console.WriteLine(cQueue.Peek());    // A
Console.WriteLine(cQueue.Dequeue()); // A
Console.WriteLine(cQueue.Peek());    // B
```
## ⚖️ `MyQueue<T>` vs `CircularQueue<T>` – Müqayisəli Cədvəl

| Xüsusiyyət         | `MyQueue<T>`                                | `CircularQueue<T>`                           |
|--------------------|----------------------------------------------|-----------------------------------------------|
| **Struktur**       | Sadə lineer massiv                           | Circular (dairəvi) massiv                     |
| **Genişlənmə**     | `Extend()` və `Shrink()` ilə                 | `Extend()` ilə dairəvi indekslə               |
| **İndeks İdarəsi** | `head`, `tail` lineer artır                  | `head`, `tail` `% capacity` ilə fırlanır      |
| **Yaddaş istifadəsi** | Artıq boşluq qala bilər, `Shrink` istifadə edir | Yaddaş daha səmərəli istifadə olunur       |

