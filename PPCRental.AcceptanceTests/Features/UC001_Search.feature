#automated
@web
Feature: UC001_Search
	As a potential customer i want search 
	I want to search for project by a simple phrase
	So that I can easily allocate project by something I remember from them.

Background: 
Given the following project
| PropertyName      | District   | Street              | Ward      | Type of Project | Beds | Bathroom | Area | Price  |
| ASA LightT        | Q.1        | Mạc Đĩnh Chi        | Bến Nghé  | Appartment      | 3    | 3        | 150  | 71000  |
| CALEDON Tan Phu   | Tân phú    | Điện Biên Phủ       | 3         | Appartment      | 2    | 2        | 130  | 55000  |
| VINH LOC Central  | Q.8        | Bà Huyện Thanh Quan | 1         | Appartment      | 3    | 2        | 120  | 70000  |
| SAIGONRESE Plaza  | Bình Thạnh | Nguyễn Bỉnh Khiêm   | 2         | Appartment      | 3    | 3        | 200  | 90000  |
| CAPSULE Residence | Gò Vấp     | Trần Hưng Đạo       | 9         | Appartment      | 2    | 2        | 130  | 49500  |
| FLORAL HOA BINH   | Q.3        | Trần Huy Liệu       | 1         | Appartment      | 4    | 4        | 180  | 79000  |
| ORIENT Plaza      | Nhà Bè     | Cao Lỗ              | Thới An   | Appartment      | 2    | 2        | 100  | 42200  |
| RIVA Garden       | Q.7        | Phan Đăng Lưu       | 11        | Appartment      | 3    | 4        | 168  | 78400  |
| CITY Gate         | Q.1        | Nguyễn Văn Cừ       | 5         | Appartment      | 4    | 4        | 250  | 120000 |
| MY HUNG Prop 3    | Bình Thạnh | Võ Thị Sáu          | Thủ Thiêm | Appartment      | 4    | 4        | 280  | 115000 |

#@mytag
Scenario: Title should be matched
	When I search for project by the phrase 'city'
	Then the list of found project should contain only: 'CITY Gate'

Scenario: Distric should be matched
	When I search for project by the phrase 'Q.12'
	Then the list of found project should contain only: 'CITY Gate'

