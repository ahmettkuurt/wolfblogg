# WolfBlog: Kurumsal Blog Yönetim Sistemi

## Proje Genel Bakış

WolfBlog, modern web teknolojileriyle geliştirilmiş, kapsamlı bir kurumsal blog yönetim sistemidir. Bu platform, içerik oluşturucuların ve yöneticilerin blog yazılarını kolayca yayınlamasına, düzenlemesine ve yönetmesine olanak tanır. Kullanıcı dostu arayüzü ve güçlü arka plan altyapısı sayesinde, etkili bir dijital iletişim stratejisi oluşturmak isteyen kurumlar için ideal bir çözümdür.

## Özellikler

*   **Kullanıcı ve Yazar Yönetimi:** Farklı yetkilere sahip kullanıcılar (yazarlar, yöneticiler) için rol tabanlı erişim kontrolü.
*   **Blog Yazısı Yönetimi:** Blog yazıları oluşturma, düzenleme, yayınlama ve taslak olarak kaydetme.
*   **Kategori Yönetimi:** Blog yazılarını kategorilere ayırma ve yönetme.
*   **Yorum Yönetimi:** Kullanıcı yorumlarını denetleme ve yanıtlama.
*   **Mesajlaşma Sistemi:** Kullanıcılar ve yöneticiler arasında dahili mesajlaşma imkanı.
*   **Duyuru ve Bildirimler:** Sistem içi duyurular ve bildirimler ile kullanıcıları bilgilendirme.
*   **Haber Bülteni Aboneliği:** Ziyaretçilerin haber bültenine abone olabilmesi.
*   **API Entegrasyonu:** Harici uygulamalarla entegrasyon için RESTful API desteği.
*   **Güvenlik:** Kimlik doğrulama ve yetkilendirme mekanizmaları ile veri güvenliği.

## Mimari

WolfBlog, katmanlı mimari prensiplerine uygun olarak tasarlanmıştır. Bu yapı, uygulamanın sürdürülebilirliğini, ölçeklenebilirliğini ve test edilebilirliğini artırır.

*   **EntityLayer:** Veritabanı tablolarını temsil eden varlık sınıflarını (modelleri) içerir.
*   **DataAccessLayer:** Veritabanı işlemleri için soyutlama katmanı sağlar. Entity Framework Core kullanılarak veritabanı ile etkileşim kurulur.
*   **BussinessLayer:** İş mantığını ve doğrulama kurallarını içerir. DataAccessLayer ile EntityLayer arasında köprü görevi görür.
*   **WolfBlog (Presentation Layer):** Kullanıcı arayüzünü ve kullanıcı etkileşimlerini yöneten ASP.NET Core MVC projesidir.
*   **WolfBlogApi:** Harici servisler veya mobil uygulamalar için RESTful API hizmetleri sunar.

## Teknolojiler

Bu proje aşağıdaki temel teknolojiler ve kütüphaneler kullanılarak geliştirilmiştir:

*   **ASP.NET Core 7.0:** Modern, yüksek performanslı ve platformlar arası web uygulamaları geliştirmek için Microsoft çatısı.
*   **Entity Framework Core 7.0:** .NET uygulamalarında veritabanı işlemleri için ORM (Object-Relational Mapper).
*   **SQL Server:** İlişkisel veritabanı yönetim sistemi.
*   **ASP.NET Core MVC:** Model-View-Controller tasarım deseni ile web uygulamaları geliştirmek için çerçeve.
*   **FluentValidation:** Güçlü ve esnek doğrulama kuralları tanımlamak için kütüphane.
*   **ClosedXML:** Excel dosyaları oluşturmak ve düzenlemek için kütüphane.
*   **X.PagedList:** Veri listelerini sayfalara ayırmak için kütüphane.
*   **Newtonsoft.Json:** JSON verileriyle çalışmak için popüler bir kütüphane.

## Kurulum

Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyin:

1.  **Depoyu Klonlayın:**

    ```bash
    git clone https://github.com/ahmettkuurt/wolfblogg.git
    cd wolfblogg
    ```

2.  **Veritabanı Yapılandırması:**
    *   `DataAccessLayer/Concrete/Context.cs` dosyasındaki bağlantı dizesini kendi SQL Server veritabanı ayarlarınıza göre güncelleyin.
    *   Veritabanı geçişlerini (`migrations`) uygulamak için aşağıdaki komutları çalıştırın:

        ```bash
        dotnet ef database update --project DataAccessLayer
        ```

3.  **Projeleri Çalıştırın:**
    *   `WolfBlog` ve `WolfBlogApi` projelerini Visual Studio veya .NET CLI üzerinden başlatın.

        ```bash
        # WolfBlog projesi için
        cd WolfBlog
        dotnet run

        # WolfBlogApi projesi için (ayrı bir terminalde)
        cd ../WolfBlogApi
        dotnet run
        ```

    Uygulama genellikle `https://localhost:7xxx` adresinde çalışacaktır.

## Kullanım

Uygulama başlatıldıktan sonra, web tarayıcınızdan erişebilirsiniz. Yönetici paneline giriş yaparak blog yazılarını, kategorileri, yorumları ve kullanıcıları yönetebilirsiniz. Yazarlar kendi blog yazılarını oluşturabilir ve düzenleyebilirler.

## Katkıda Bulunma

Katkılarınız için teşekkür ederiz! Projeye katkıda bulunmak isterseniz, lütfen aşağıdaki adımları izleyin:

1.  Depoyu forklayın.
2.  Yeni bir özellik veya hata düzeltmesi için yeni bir dal (branch) oluşturun (`git checkout -b feature/AmazingFeature`).
3.  Değişikliklerinizi yapın ve commit edin (`git commit -m 'Add some AmazingFeature'`).
4.  Dalınızı uzak depoya (remote) push edin (`git push origin feature/AmazingFeature`).
5.  Bir Pull Request (Çekme İsteği) açın.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.

## İletişim

Ahmet Kurt - [ahmettkurt@example.com](mailto:ahmettkurt@example.com)

Proje Bağlantısı: [https://github.com/ahmettkuurt/wolfblogg](https://github.com/ahmettkuurt/wolfblogg)
