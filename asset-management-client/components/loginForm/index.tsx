'use client';
import { useState } from 'react'
import { useRouter } from 'next/navigation'
import { loginfunc } from '@/api/auth/login';

export default function LoginForm() {

  const [error, setError] = useState('');
  const [seccess, setSeccess] = useState('');

  async function loginSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    const loginData = new FormData(e.currentTarget);
    const _email = loginData.get('username') as string;
    const _password = loginData.get('password') as string;
    try {
      if (await loginfunc(loginData) === 200) {
        console.log('Login successful');
        // router.push('/dashboard');
        setSeccess('Login successful');
        // clean error
        setError('');
      }
    } catch (error) {
      console.log('Invalid credentials');
      setError('user name or password increct!');
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
      {/* <div className="block items-center justify-center">
        <a className="text-center block mx-auto mt-2" href='/auth/register'>Forgot password?</a>
      </div> */}

      <div className="signinreg-divider flex text-base items-center px-4 my-4">
        <div className="flex-1 h-px bg-gray-300 mr-4"></div>
        <div className="flex-1 h-px bg-gray-300 ml-4"></div>
      </div>


    </div>
  )
}