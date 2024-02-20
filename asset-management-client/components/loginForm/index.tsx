'use client';
import { useState } from 'react'
import { useRouter } from 'next/navigation'
import { loginfunc } from '@/api/auth/login';

export default function LoginForm() {

  async function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    const loginData = new FormData(e.currentTarget);
    const _email = loginData.get('username') as string;
    const _password = loginData.get('password') as string;
    e.preventDefault();
    // const response = loginfunc(_email, _password);

    try {
      if (await loginfunc(_email, _password) === 200) {
        console.log('Login successful');
        // router.push('/dashboard');
      }
    } catch (error) {
      console.log('Invalid credentials');
    }
  }

  return (
    <div className="block items-center justify-center">
      <p className="text-2l font-bold pb-3 text-[#4F5864] text-center">Login using your email</p>
      <div className="block items-center justify-center">
        <form onSubmit={handleSubmit} className='block items-center justify-center'>
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
          <button type="submit"
            className="bg-[#1EB3EC] rounded-full border-4 w-full px-32 py-1 text-white text-center">Login</button>

        </form>
      </div>
      <div className="block items-center justify-center">
        <a className="text-center block mx-auto mt-2" href='/auth/register'>Forgot password?</a>
      </div>

      <div className="signinreg-divider flex text-base items-center px-4 my-4">
        <div className="flex-1 h-px bg-gray-300 mr-4"></div>
        <div className="flex-1 h-px bg-gray-300 ml-4"></div>
      </div>


    </div>
  )
}