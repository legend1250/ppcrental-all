﻿#automated

Feature: UC001_Search
	As a potential customer i want search 
	I want to search for project by a simple phrase
	So that I can easily allocate project by something I remember from them.

Background: 
Given the following project
| PropertyName      | Avatar                 | Images       | PropertyType | Content                                                                                                                                                                                                                                                                                                                                                                                                                                         | Street           | Ward          | District      | Price  | UnitPrice | Area | Bedroom | Bathroom | PackingPlace | User                     | Status   | Note |
| ASA LightT        | Asa Light.jpg          |              | Apartment    | NaN                                                                                                                                                                                                                                                                                                                                                                                                                                             | Bùi Viện         | P.Bến Nghé    | Quận 1        | 71000  | USD       | 150  | 3       | 3        | 1            | lythihuyenchau@gmail.com | Đã duyệt | Done |
| CALEDON Tan Phu   | Caledon Tan Phu.jpg    |              | Villa        | ICON 56 – Modern Style Apartment $ 950 Per Month.Condominium in Rentals 56 Ben Van Don, Ho Chi Minh City, District 4 add to favorites. 22 See all 12 photos.Icon 56 is 4 star building with strategic location and excellent amenities including infinity swimming pool and modern gym. Just walking through Mong bridge (Saigon oldest bridge) or drive through Calmette bridge, you have reached District 1 – the business center of the city | Bà Lê Chân       | P.Đa Kao      | Quận 1        | 55000  | USD       | 130  | 2       | 2        | 1            | lythihuyenchau@gmail.com | Đã duyệt | Done |
| VINH LOC Central  | Vinh Loc Central.jpg   |              | Villa        | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished, with attention to details, modern colors, designer lighting and high quality accessories.                                                                                                                                                                                                                                            | Đồng Khởi        | P.Cô Giang    | Quận 1        | 70000  | USD       | 120  | 3       | 2        | 1            | lythihuyenchau@gmail.com | Đã duyệt | Done |
| SAIGONRESE Plaza  | Saigonrese.jpg         |              | Office       | Very close to the Super Market Co.op Mart Phan Xich Long, 3 min from the Swimming Pool Rach Mieu and also close to the Gym/Yoga on Phan Xich Long Street. 3 min go to Tan Dinh market or Phu Nhuan market.                                                                                                                                                                                                                                      | Chu Văn An       | P.Phú Hữu     | Quận 2        | 90000  | USD       | 200  | 3       | 3        | 1            | lythihuyenchau@gmail.com | Đã duyệt | Done |
| CAPSULE Residence | Capsule Residence .jpg |              | Office       | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs.. Behind the industrial glass wall you will find the bedroom area with a double bed and a large closet.                                                                                                                                                                                                                                       | Thảo Điền        | P.An Lợi Đông | Quận 2        | 49500  | USD       | 130  | 2       | 2        | 1            | lythihuyenchau@gmail.com | Đã duyệt | Done |
| FLORAL HOA BINH   | Floral Hoa Binh.jpg    |              | Villa        | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. Located in Binh Thanh District, it is within easy reach of the new Metro Line No. 1 Ben Thanh – Suoi Tien, 4 minutes to downtown District 1 and 3 minutes to the new Thu Thiem urban area in the near future.                                                                                                                      | Nguyễn Tư Nghiêm | P.An Phú      | Quận 2        | 79000  | USD       | 180  | 4       | 4        | 1            | lythihuyenchau@gmail.com | Đã duyệt | Done |
| ORIENT Plaza      | Orient Plaza.jpg       |              | Apartment    | Located on Nguyen Huu Canh Street, this nice apartment has all amenities like swimming pool, sauna, jacuzzi, gym and pet allowed…It has fully furnished with everything you need like TV, fridge, washing machine, wardrobe, sofa, dining table, kitchenette, …With $1600/month for 3 bedroom apartment. Inclusive of management fee                                                                                                            | Nguyễn Tư Nghiêm | P.01          | Quận 3        | 42200  | USD       | 100  | 2       | 2        | 1            | annguyen                 | Đã duyệt | Done |
| RIVA Garden       | Riva Garden.jpg        |              | Apartment    | The Nguyen Dinh Chinh  is a lovely option for the renter seeking home-comfort away from the noise of the city center. Located in Phu Nhuan district, the unit is conveniently accessible to local shops and eateries. This serviced apartment provides space and everything needed for you to feel at home.                                                                                                                                     | Vườn Chuối       | P.02          | Quận 3        | 78400  | USD       | 168  | 3       | 4        | 2            | annguyen                 | Đã duyệt | Done |
| CITY Gate         | City Gate.jpg          |              | Villa        | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…Live here, and the best and most beloved sites of the city will be just outside your door – from the cafes and restaurants of the financial district, to the waterfront shops and attractions of downtown Ben Thanh. It’s all just steps away.                                                                                                 | Nguyễn Hiền      | P.03          | Quận 3        | 120000 | USD       | 250  | 4       | 4        | 2            | Thang@gmail.com          | Đã duyệt | Done |
| MY HUNG Prop 3    | My Hung Prop.jpg       |              | Villa        | NaN                                                                                                                                                                                                                                                                                                                                                                                                                                             | Phú Lâm A        | P.07          | Quận 6        | 115000 | USD       | 280  | 4       | 4        | 2            | lythihuyenchau@gmail.com | Đã duyệt | Done |
| NovaLand          | NovaLand.jpg           | NovaLand.jpg | House        | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs.. Behind the industrial glass wall you will find the bedroom area with a double bed and a large closet.                                                                                                                                                                                                                                       | Đặng Dung        | P.Bình Khánh  | Q. Bình Thạnh | 45000  | USD       |      | 2       | 2        | 2            | annguyen                 | Đã duyệt | Done |

@automated
Scenario: Space should be treated as multiple OR search
	When I search for project by the phrase 'CITY Gate'
	Then the list of found project should contain only: 'CITY Gate'
	| PropertyName | Avatar        | Images | PropertyType | Content                                                                                                                                                                                                                                                                                                                                         | Street      | Ward | District | Price  | UnitPrice | Area | Bedroom | Bathroom | PackingPlace | User            | Status   | Note |
	| CITY Gate    | City Gate.jpg |        | Villa        | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…Live here, and the best and most beloved sites of the city will be just outside your door – from the cafes and restaurants of the financial district, to the waterfront shops and attractions of downtown Ben Thanh. It’s all just steps away. | Nguyễn Hiền | P.03 | Quận 3   | 120000 | USD       | 250  | 4       | 4        | 2            | Thang@gmail.com | Đã duyệt | Done |

Scenario: Title should be matched
	When I search for project by the phrase 'Garden'
	Then the list of found project should contain only: 'RIVA Garden'
	| PropertyName | Avatar         | Images | PropertyType | Content                                                                                                                                                                                                                                                                                                                                         | Street      | Ward | District | Price  | UnitPrice | Area | Bedroom | Bathroom | PackingPlace | User            | Status   | Note |
	| RIVA Garden  | Riva Garden.jpg|        | Apartment    | The Nguyen Dinh Chinh  is a lovely option for the renter seeking home-comfort away from the noise of the city center. Located in Phu Nhuan district, the unit is conveniently accessible to local shops and eateries. This serviced apartment provides space and everything needed for you to feel at home.                                     | Vườn Chuối  | P.02 | Quận 3   | 78400  | USD       | 168  | 3       | 4        | 2            | annguyen        | Đã duyệt | Done |

Scenario: Search result should be ordered by project title 
 When I search for books by the phrase 'id'
 Then the list of found books should be:
 | PropertyName      |
 | CALEDON Tan Phu   |
 | CAPSULE Residence |
 | ORIENT Plaza      |
 | RIVA Garden       |
 | CITY Gate         |
