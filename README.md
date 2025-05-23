# SpartaChapter5
### 프로젝트 내용
스파르타 Chapter6 개인 과제 제출용입니다.

---

### 개발 기간
2025/05/20 ~ 2025/05/23

---

### 와이어프레임...
![Image](https://github.com/user-attachments/assets/071999e3-f5c7-40d5-8a3f-7b8004f792ee)

---

### 객체지향을 위한 발버둥
![Image](https://github.com/user-attachments/assets/bf4fcc4c-660e-492a-ba9f-3454c391715f)
---

### 영상
![Image](https://github.com/user-attachments/assets/a1c843c0-c40a-4c66-984f-13ded9774e1c)
---
### 구현한 기능

##### 1. 기본 이동 및 점프

Input Action에 Invoke Unity Events를 사용해 구현했습니다.

##### 2. 체력바 UI

체력, 스테미나의 값 변동이 UI에 반영되도록 구현했습니다.

##### 3. 동적 환경 조사

RayCast를 이용해 오브젝트를 조사하고 인벤토리에 저장할 수 있도록 구현했습니다.

##### 4. 점프대

triggerEnter된 오브젝트의 RigidBody를 가져와 addForce 하도록 구현했습니다.

##### 5. 아이템 데이터

ScriptableObject를 상속받아 에셋을 생성할 수 있도록 구현했습니다.

##### 6. 아이템 사용

코루틴을 사용해 스테미나가 10초동안 회복되도록, UI가 깜빡이도록 구현했습니다.

---

### 구현하지 못한 기능, 부족한 점

1. 카메라가 바라보는 방향대로 전진하도록 구현하고자 하였으나 실패했습니다.

2. 체력이 증감되는 상황을 만들지 못했습니다. 기능은 작동할것 같습니다.

3. 아이템 장착만 구현하고 해제, 사용등은 구현하지 못했습니다.
