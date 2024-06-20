import { useState } from 'react';

export default function useToken() {
    const getToken = () => {
        const tokenString = localStorage.getItem('token');
        // Kiểm tra nếu tokenString là null hoặc undefined
        if (!tokenString) {
          return null; // hoặc giá trị mặc định khác tùy vào yêu cầu của bạn
        }
        try {
          const userToken = JSON.parse(tokenString);
          return userToken?.token; // Lấy token từ đối tượng parsed
        } catch (error) {
          console.error('Error parsing token from localStorage:', error);
          return null; // hoặc xử lý khác theo ý của bạn
        }
      };
      
      

  const [token, setToken] = useState(getToken());

  const saveToken = userToken => {
    localStorage.setItem('token', JSON.stringify(userToken));
    setToken(userToken);
    console.log(token);
  };

  return {
    setToken: saveToken,
    token
  }
}