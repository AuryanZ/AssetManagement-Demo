// footer
import React from 'react';

const Footer = () => {
    const year = new Date().getFullYear();
    return (
        <footer className='px-4 p-5 bottom-0 w-full'>
            <hr />
            <p className='text-center pt-4'>© {year} Rui Z All Right Reserved</p>
        </footer>
    );
}


export default Footer;