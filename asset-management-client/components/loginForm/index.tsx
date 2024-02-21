'use client';
import { useState } from 'react'
import { useRouter } from 'next/navigation'
import { loginfunc } from '@/api/auth/login';
import { getUserInfo } from '@/api/auth/userInfo';
import router from 'next/router';

export default function LoginForm() {

  const [error, setError] = useState('');
  const [seccess, setSeccess] = useState('');
  const router = useRouter();

  async function loginSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    const loginData = new FormData(e.currentTarget);
    try {
      if (await loginfunc(loginData) === 200) {
        setSeccess('Login successful');
        setError('');

        const username = loginData.get('username')?.toString(); // Add null check here
        const userRole = username ? await getUserInfo(username) : null; // Add null check here
        console.log(userRole['role'])
        if (userRole['role'] === 'user') { // Add null check here
          router.push('/dashboard/user');
        }else if(userRole['role'] === 'admin'){
          router.push('/dashboard/admin');
        }
      }
    } catch (error) {
      console.log('Invalid credentials');
      setError('user name or password incorrect!');
    }
  }

  return (
    <div className="block items-center justify-center">
      <p className="text-2l font-bold pb-3 text-[#4F5864] text-center">Login</p>
      <div className="block items-center justify-center">
        <form onSubmit={loginSubmit} className='block items-center justify-center'>
          <input
            type="text"
            name="username"
            placeholder='User Name or Email Address'
            className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
          />

          <input
            type="text"
            name="password"
            className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-2 rounded-md"
            placeholder='Password'
          />
          {error ? (
            <p className="text-red-500 text-center">{error}</p>
          ) : (
            <p className="text-green-500 text-center">{seccess}</p>
          )}
          <button type="submit"
            className="bg-[#1EB3EC] rounded-full border-4 w-full px-32 py-1 text-white text-center">Login</button>

        </form>
      </div>
      <div className="signinreg-divider flex text-base items-center px-4 my-4">
        <div className="flex-1 h-px bg-gray-300 mr-4"></div>
        <div className="flex-1 h-px bg-gray-300 ml-4"></div>
      </div>


    </div>
  )
}