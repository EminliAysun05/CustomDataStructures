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

## 🔗 `CustomLinkedList<T>` 

📁 **Fayl:** `LinkedList/CustomLinkedList.cs`

### 🔍 Təsviri
`CustomLinkedList<T>` sinfi, C# dilində özəl şəkildə tək istiqamətli (singly) bağlı siyahı (linked list) strukturunun implementasiyasıdır. Bu struktur istənilən tip (`T`) üzərində işləyir və `IEnumerable<T>` interfeysini dəstəklədiyi üçün `foreach` ilə iterasiya edilə bilir.

---

### 🧱 Daxili Quruluş
Hər bir element `Node<T>` adlı nested siniflə təmsil olunur. Bu sinif aşağıdakı sahələrə malikdir:

- `T Data` – Həmin node-un dəyəri
- `Node<T> Next` – Növbəti node-a istinad

```csharp
public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
    }
}
```
### 🔧 Əsas Metodlar

| Metod                      | Təsviri                                                                 |
|----------------------------|-------------------------------------------------------------------------|
| `AddFirst(T data)`         | Siyahının əvvəlinə yeni node əlavə edir                                 |
| `AddLast(T data)`          | Siyahının sonuna yeni node əlavə edir                                  |
| `AddLast(IEnumerable<T>)` | Bir neçə elementi ardıcıl şəkildə sona əlavə edir                       |
| `AddMiddle(T data, int)`   | Verilmiş indeksə yeni node əlavə edir                                   |
| `RemoveFirst()`            | Siyahının ilk elementini silir                                          |
| `RemoveLast()`             | Siyahının son elementini silir                                          |
| `RemoveWithValue(T val)`   | Verilən dəyərə uyğun ilk node-u tapıb silir                             |
| `GetEnumerator()`          | `foreach` dövrü ilə siyahı üzərində iterasiya imkanı verir               |

---

### ✅ İstifadə nümunəsi

```csharp
var list = new CustomLinkedList<int>();

list.AddFirst(10);
list.AddLast(20);
list.AddMiddle(15, 1);

foreach (var item in list)
{
    Console.WriteLine(item); // 10, 15, 20
}

list.RemoveWithValue(15);
list.RemoveLast();
list.RemoveFirst();
```
### 🧠 Əlavə Qeydlər

- `AddMiddle` metodu indeks `0` olduqda avtomatik olaraq `AddFirst()` metodunu çağırır.
- `RemoveWithValue` yalnız **ilk uyğun dəyəri** silir, digər eyni dəyərlər qalır.
- `RemoveLast()` metodu son elementi tapmaq üçün siyahını başdan sona qədər gəzir — bu da **O(n)** zaman mürəkkəbliyinə səbəb olur.
- `IEnumerable<T>` interfeysinin implementasiyası sayəsində bu struktur `foreach` dövrü ilə rahat istifadə oluna bilir.
## 📌 Yekun

Bu layihə fundamental məlumat strukturlarının – `LinkedList`, `Queue` və `Stack` kimi nüvəsini təşkil edən strukturların – C# dilində sıfırdan necə qurulacağını nümayiş etdirir. Hər bir strukturun əsas funksionallıqları – əlavəetmə, silmə, iterasiya və yaddaş idarəsi – ətraflı şəkildə tətbiq edilmiş və kodun təmizliyi ön planda tutulmuşdur.

Layihə həm öyrənmək istəyən yeni başlayanlar, həm də biliklərini praktika ilə möhkəmləndirmək istəyən inkişaf etdiricilər üçün nəzərdə tutulub. Kodlar genişlənə biləcək şəkildə dizayn edildiyi üçün istənilən funksionallıq asanlıqla əlavə oluna bilər.

> Bu repository, məlumat strukturlarını dərindən başa düşmək və real dünyada istifadə edilən prinsipləri özündə əks etdirmək üçün etibarlı bir başlanğıc nöqtəsidir.
