import axios from 'axios'

export const api = axios.create({
  baseURL: 'https://localhost:44391',
  timeout: 5000,
  headers: authHeader(),
})

function authHeader() {
  let user = JSON.parse(localStorage.getItem('user'));

  if (user && user.token) {
    return { 'Authorization': 'Bearer ' + user.token };
  } else {
    return {};
  }
}